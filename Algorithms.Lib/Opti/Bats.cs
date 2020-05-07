using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.Opti
{
    using System.Diagnostics;
    using Utils;
    public class Bats : IOptiAlg
    {

        private static Random rnd = new Random();
        //Fancy math stuff
        public double[] searchSpace = { -10.0, 10.0 };
        public int dimension = 10;

        public double[] initialFrequency = { 0, 1.0 };


        public int iterCount = 100000;
        public int populationCount = 50;
        public int flightIters = 40;
        public double loudnessDecreaseFactor = 0.9;
        public double[] initialLoudness = { 1.0, 2.0 };
        public double[] initialPulseRate = { 0.0, 1.0 };



        public double[] Opti(Func<double[], double> func)
        {
            //Based on https://arxiv.org/pdf/1004.4170.pdf
            //Initialize bat population
            List<Bat> population = new List<Bat>();
            for (int i = 0; i < populationCount; i++)
            {
                Bat b = new Bat(rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1]));
                b.lastFitness = func(b.position);
                b.frequency = initialFrequency[0] + (initialFrequency[1] - initialFrequency[0]) * rnd.NextDouble();
                b.loudness = rnd.RandomNormal(initialLoudness[0], initialLoudness[1], 1);
                b.initialPulseRate = rnd.RandomNormal(initialPulseRate[0], initialPulseRate[1], 1);
                b.pulseRate = b.initialPulseRate;
                population.Add(b);
            }

            population = population.OrderBy(x => x.lastFitness).ToList();
            double[] best = population[0].position;
            Bat watch = population[0];

            for (int iter = 0; iter < iterCount; iter++)
            {
                foreach (Bat b in population)
                {

                    b.frequency = initialFrequency[0] + (initialFrequency[1] - initialFrequency[0]) * rnd.NextDouble();
                    //update velocity and position
                    for (int dim = 0; dim < dimension; dim++)
                    {
                        b.velocity[dim] = b.velocity[dim] + (b.position[dim] - best[dim]) * b.frequency;
                        b.position[dim] = b.position[dim] + b.velocity[dim];
                    }


                    double[] currentPos = b.position;
                    if (rnd.NextDouble() > b.pulseRate)
                    {

                        double avgLoudness = 1;
                        //Generate a new local solution around the current best soulution
                        double epsilon = rnd.RandomNormal(-1.0, 1.0, 1);
                        avgLoudness = population.Average(x => x.loudness);
                        for (int dim = 0; dim < dimension; dim++)
                        {
                            currentPos[dim] = best[dim] + epsilon * avgLoudness;
                        }
                        currentPos = RandomWalk(currentPos, flightIters, avgLoudness);
                    }



                    if (rnd.NextDouble() < b.loudness && func(currentPos) < func(b.position))
                    {
                        b.position = currentPos;
                        b.loudness *= loudnessDecreaseFactor;
                        b.pulseRate = (1 - Math.Exp(-loudnessDecreaseFactor * iter));
                        if (b == population[0])
                            Debug.WriteLine(b.loudness + " || " + b.pulseRate);
                    }

                    b.lastFitness = func(b.position);
                    if (func(b.position) < func(best))
                    {
                        b.position.CopyTo(best, 0);

                    }
                }


                //Rank the bats and find the current best bat
                //population.ForEach(x => x.lastFitness = func(x.position));
                //best = population.Aggregate((x, y) => x.lastFitness < y.lastFitness ? x : y);
            }

            //Return best bat solution
            return best;
        }




        private class Bat
        {
            public double[] velocity;
            public double[] position;
            public double lastFitness;
            public double frequency;
            public double pulseRate;
            public double initialPulseRate;
            public double loudness;



            public Bat(double[] position)
            {
                this.position = position;
                this.velocity = new double[position.Length];
            }


            /// <summary>
            /// Calculates distance from given targetBat and assigns distanceFromBest
            /// </summary>
            /// <param name="targetBat"></param>
            public double CalculateDistance(Bat targetBat)
            {
                if (targetBat.position.Length != position.Length)
                    throw new ArgumentException("Bats dimensionality is not equal");

                //Calculate distance to the best bat using Cartesian metric
                double distance = 0;
                for (int i = 0; i < position.Length; i++)
                {
                    distance += Math.Pow(position[i] - targetBat.position[i], 2.0);
                }
                distance = Math.Sqrt(distance);
                return distance;
            }

        }

        public double[] RandomWalk(double[] position, int iterCount, double walkStepSizeMod)
        {
            double[] result = new double[position.Length];
            position.CopyTo(result, 0);
            for (int i = 0; i < iterCount; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    result[j] += rnd.RandomNormal(-1.0, 1.0, 1) * walkStepSizeMod;
                }
            }
            return result;
        }



    }

}