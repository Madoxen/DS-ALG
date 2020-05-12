using System;
using Algorithms.Lib.Opti;
using System.Linq;
namespace Algorithms.Lib.Opti
{
    using System.Collections.Generic;
    using Utils;
    public class Bees : IOptiAlg
    {

        private static Random rnd = new Random();
        public int populationCount = 1000;
        public int dimension = 10;
        public int generations = 10000;
        public double[] searchSpace = { -10.0, 10.0 };
        public int foodSourceCycleLimit = 5;
        public int onlookers = 100;


        public double[] Opti(Func<double[], double> func)
        {
            //Initialize population list
            double[] bestBeePos = new double[dimension];
            double bestFitness = double.MaxValue;
            List<Bee> hive = new List<Bee>();
            for (int i = 0; i < populationCount; i++)
            {
                hive.Add(new Bee(rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1])));
            }

            for (int gen = 0; gen < generations; gen++)
            {
                double hiveFitness = 0; //used for determining roulette space
                //WORKER
                for (int i = 0; i < hive.Count; i++)
                {
                    double[] candidate = new double[dimension];
                    hive[i].position.CopyTo(candidate, 0);
                    int dim = rnd.Next(0, dimension);
                    int randHiveIndex = ChooseBeeOtherThenIndex(i, hive);
                    candidate[dim] = hive[i].position[dim] + rnd.RandomNormal(-1, -1, 1) * (hive[i].position[dim] - hive[randHiveIndex].position[dim]);

                    hive[i].currentFitness = func(hive[i].position);
                    double possibleFitness = func(candidate);
                    //Check if candidate is better
                    if (possibleFitness < hive[i].currentFitness)
                    {
                        hive[i].position = candidate;
                        hive[i].currentFitness = possibleFitness;
                    }

                    hiveFitness += hive[i].currentFitness;
                }

                //ONLOOKER PASS
                for (int j = 0; j < onlookers; j++)
                {
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



                    if (hive[index].currentFitness >= hive[index].lastFitness)
                    {
                        hive[index].timesImprovementFailed++;
                    }
                    //SCOUT
                    if (hive[index].timesImprovementFailed >= foodSourceCycleLimit)
                    {
                        //this foodsource did not improve in last foodSourceCycliLimit
                        //Search for better one
                        hive[index].position = rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1]);
                    }
                    else
                    {
                        hive[index].lastFitness = hive[index].currentFitness; //update last fitness
                    }



                }

                double[] bestCandidate = hive.Aggregate((x, y) => x.currentFitness < y.currentFitness ? x : y).position;
                double candidateFitness = func(bestCandidate);
                if (candidateFitness < bestFitness)
                {
                    bestBeePos = bestCandidate;
                    bestFitness = candidateFitness;
                }
            }

            return bestBeePos;
        }


        private class Bee
        {
            public double[] position;
            public double lastFitness = double.MaxValue;
            public double currentFitness = double.MaxValue;
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