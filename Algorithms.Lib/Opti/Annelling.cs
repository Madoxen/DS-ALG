using System;
using Algorithms.Lib.Utils;

namespace Algorithms.Lib.Opti
{
    public class Annealing : IOptiAlg
    {
        public int iterTreshold;
        public double maxTemp;
        public int dimensions;
        public double minVal;
        public double[] searchSpace;
        static Random rand = new Random();

        public Annealing(int iterTreshold, double maxTemp)
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

            
            double[] currentState = rand.GenerateRandomArray(dimensions, searchSpace[0], searchSpace[1]);
            double[] bestState = currentState;
            double T = maxTemp;
            double alpha = 0.999;
            for (int i = 0; i < iterTreshold; i++)
            {

               // Create adjacent state.
              //  double[] newStateDelta = rand.GenerateRandomArray(dimensions, -1.0, 1.0);
                double[] newState = new double[dimensions];
                currentState.CopyTo(newState,0);
                for(int j = 0; j < dimensions; j++)
                {
                    newState[j] += rand.RandomNormal(-1.0, 1.0, 1) * T;
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
                return Math.Exp(-(adjEnergy - energy) / currTemp);
        }

        
    }
}