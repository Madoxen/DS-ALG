using System;
using Algorithms.Lib.Opti;

namespace Algorithms.Lib
{
    using System.Collections.Generic;
    using Utils;
    public class Bees : IOptiAlg
    {

        private static Random rnd = new Random();
        public int populationCount = 1000;
        public int dimension = 10;
        public int generations = 1000;
        public double[] searchSpace = { -10.0, 10.0 };
        public int foodSourceCycleLimit = 5;


        public double[] Opti(Func<double[], double> func)
        {
            //Initialize population list
            List<Bee> hive = new List<Bee>();
            for (int i = 0; i < populationCount; i++)
            {
                hive.Add(new Bee(rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1])));
            }

            for (int gen = 0; gen < generations; gen++)
            {
                double hiveFitness = 0;
                //WORKER
                for (int i = 0; i < hive.Count; i++)
                {
                    double[] candidate = new double[dimension];
                    int dim = rnd.Next(0, hive.Count);
                    int randHiveIndex = ChooseBeeOtherThenIndex(i, hive);
                    candidate[dim] = hive[i].position[dim] + rnd.RandomNormal(-1, -1, 1) * (hive[i].position[dim] - hive[randHiveIndex].position[dim]);


                    //Check if candidate is better
                    if (func(candidate) < func(hive[i].position))
                        hive[i].position = candidate;


                    hive[i].lastFitness = func(hive[i].position);
                    hiveFitness += hive[i].lastFitness;
                }

                //ONLOOKER PASS

                //roulette
                double roll = rnd.RandomNormal(0, hiveFitness, 1);
                double sum = 0;
                int index = 0;
                for (int i = 0; i < hive.Count; i++)
                {
                    if (roll >= sum && roll <= sum + hive[i].lastFitness)
                        index = i;
                    sum += hive[i].lastFitness;
                }

                if()

            }



        }


        private class Bee
        {
            public double[] position;
            public double lastFitness = 0;
            public int timesImprovementFailed = 0;

            public Bee(double[] position)
            {
                this.position = position;
            }


        }

        private int ChooseBeeOtherThenIndex(int beeIndex, List<Bee> hive)
        {
            int otherBeeIndex = beeIndex;
            while (otherBeeIndex == beeIndex) //i know this is bad, but in bigger collections it's simply better to just reroll then construct whole new list (which would be O(N))
            {
                otherBeeIndex = rnd.Next(0, hive.Count);
            }
            return otherBeeIndex;
        }


    }

}