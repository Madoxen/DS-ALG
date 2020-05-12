using System;
using System.Collections.Generic;
using System.Linq;
namespace Algorithms.Lib.Opti
{
    using Utils;
    public class Cuckoo : IOptiAlg
    {

        private static Random random = new Random();
        public int nestCount = 50;
        public int dimension = 10;
        public int iterCount = 50000;
        public double[] searchSpace = { -10.0, 10.0 };



        //Gaussian random walk iteration count
        public int walkIterCount = 10;
        public double walkStepSizeMod = 0.1;
        public double populationSurvivalRate = 0.9;

        public Cuckoo() { }


        public double[] Opti(Func<double[], double> func)
        {
            List<double[]> nests = new List<double[]>();

            //Generate nestCount nests
            for (int i = 0; i < nestCount; i++)
            {
                nests.Add(random.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1]));
            }


            //Perform search
            for (int i = 0; i < iterCount; i++)
            {
                //Choose random nest 
                int cuckooNestIndex = random.Next(0, nests.Count);
                //move cuckoo with random walk
                double[] flightResult = randomWalk(nests[cuckooNestIndex], walkIterCount);
                int cuckedNestIndex = ChooseCuckedNest(cuckooNestIndex, nests);

                //Compare solutions
                if (func(flightResult) <= func(nests[cuckedNestIndex]))
                    //replace solution with better one
                    nests[cuckedNestIndex] = flightResult;

                //Order by fitness
                nests = nests.OrderBy(x => func(x)).ToList();
                //Kill weakest nests
                KillPop(nests, populationSurvivalRate);
                //Add new solutions to meet pop cap
                for (int j = nests.Count; j < nestCount; j++)
                {
                    nests.Add(random.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1]));
                }
            }

            //After cuckoo did it's job, now it's the time to choose a winner
            nests = nests.OrderBy(x => func(x)).ToList();
            return nests[0];
        }


        private double[] randomWalk(double[] startingPoint, int iterCount)
        {
            double[] result = new double[startingPoint.Length];
            startingPoint.CopyTo(result, 0);
            for (int i = 0; i < iterCount; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    result[j] += random.RandomNormal(-1.0, 1.0, 100) * walkStepSizeMod;
                }
            }
            return result;
        }


        private int ChooseCuckedNest(int cuckooNestIndex, List<double[]> nests)
        {
            int cuckedNestIndex = cuckooNestIndex;
            while (cuckedNestIndex == cuckooNestIndex) //i know this is bad, but in bigger collections it's simply better to just reroll then construct whole new list (which would be O(N))
            {
                cuckedNestIndex = random.Next(0, nests.Count);
            }
            return cuckedNestIndex;
        }


        /// <summary>
        /// Only the strongest will survive!
        /// </summary>
        /// <param name="population">ORDERED by fitness collection of critters</param>
        private void KillPop(List<double[]> population, double populationSurvivalRate)
        {
            int index = (int)((double)population.Count * populationSurvivalRate);
            population.RemoveRange(index, population.Count - index);
        }

    }

}