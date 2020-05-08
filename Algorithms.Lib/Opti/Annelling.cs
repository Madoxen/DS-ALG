using System;
using Algorithms.Lib.Utils;

namespace Algorithms.Lib.Opti
{
    public class Anneling : IOptiAlg
    {
        public int iterTreshold;
        public double maxTemp;
        public int dimensions;
        public double[] searchSpace;
        static Random rand = new Random();

        public Anneling(int iterTreshold, double maxTemp)
        {
            this.maxTemp = maxTemp;
            this.iterTreshold = iterTreshold;
        }

        public double[] Opti(Func<double[], double> func)
        {
            /*
            Let s = s0
            For k = 0 through kmax (exclusive):
                T ← temperature( (k+1)/kmax )
                Pick a random neighbour, snew ← neighbour(s)
                If P(E(s), E(snew), T) ≥ random(0, 1):
                    s ← snew
            Output: the final state s
            */
            //In order to apply the simulated annealing method to
            // a specific problem, one must specify the following parameters: 
            //the state space, 
            //the energy (goal) function E(), 
            //the candidate generator procedure neighbour(), 
            //the acceptance probability function P(),

            double[] currentState = rand.GenerateRandomArray(dimensions, searchSpace[0], searchSpace[1]);
            double T = maxTemp;
            double alpha = 0.995;
            for (int i = 0; i < iterTreshold; i++)
            {
                // Create adjacent state.
                // Compute energy of adjacent state.
                // Check if adjacent state is new best.
                // If adjacent state better, accept state with varying probability.
                // Decrease temperature and increase iteration counter.

                double[] newState = rand.GenerateRandomArray(dimensions, -1.0, 1.0);
                for(int j = 0; j < dimensions; j++)
                {
                    newState[j] += currentState[j];
                }
                //In our case energy is simply value of objective function
                if (AcceptanceProb(func(currentState), func(newState), T) >= rand.NextDouble())
                    currentState = newState;

                T = T * alpha;
            }
            return currentState;
        }


        static double AcceptanceProb(double energy, double adjEnergy, double currTemp)
        {
            //In the formulation of the method by Kirkpatrick et al., the acceptance probability function P ( e , e ′ , T ) {\displaystyle P(e,e',T)} P(e,e',T) was defined as 1 if e ′ < e {\displaystyle e'<e} e'<e, and exp ⁡ ( − ( e ′ − e ) / T ) {\displaystyle \exp(-(e'-e)/T)} \exp(-(e'-e)/T) otherwise
            //from https://en.wikipedia.org/wiki/Simulated_annealing
            if (adjEnergy < energy)
                return 1.0;
            else
                return Math.Exp((energy - adjEnergy) / currTemp);
        }
    }
}