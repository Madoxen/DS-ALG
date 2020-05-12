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

        public double[] initialFrequency = { 0, 0.1 };


        public int iterCount = 10000;
        public int populationCount = 2000;
        public int flightIters = 20;
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
                population.Add(b);
            }

            population = population.OrderBy(x => x.lastFitness).ToList();
            double[] best = population[0].position;

            for (int iter = 0; iter < iterCount; iter++)
            {
                //Find best bat in current iteration
                population.ForEach(x => x.lastFitness = func(x.position));
                best = population.Aggregate((x, y) => x.lastFitness < y.lastFitness ? x : y).position;
                foreach (Bat b in population)
                {

                    b.frequency = initialFrequency[0] + (initialFrequency[1] - initialFrequency[0]) * rnd.NextDouble();
                    //update velocity and position
                    double[] candidatePosition = new double[dimension];
                    double[] candidateVelocity = new double[dimension];


                    //Local solution generation
                    if (rnd.NextDouble() > 0.99) //1%chance
                    {
                        double avgLoudness = 1;
                        avgLoudness = population.Average(x => x.loudness);
                        for (int i = 0; i < flightIters; i++)
                        {
                            candidateVelocity = rnd.GenerateRandomArray(dimension, -1.0, 1.0);
                            for (int dim = 0; dim < dimension; dim++)
                            {
                                candidatePosition[dim] = best[dim] + candidateVelocity[dim] * avgLoudness;
                            }
                        }
                    }
                    else
                    {
                        for (int dim = 0; dim < dimension; dim++)
                        {
                            candidateVelocity[dim] = b.velocity[dim] + (b.position[dim] - best[dim]) * b.frequency;
                            candidatePosition[dim] = b.position[dim] + candidateVelocity[dim];
                        }
                    }



                    if (rnd.NextDouble() < 0.01 || func(candidatePosition) < func(b.position))
                    {
                        b.position = candidatePosition;
                        b.velocity = candidateVelocity;
                        b.loudness *= loudnessDecreaseFactor;
                        if (func(b.position) < func(best))
                        {
                            b.position.CopyTo(best, 0);
                        }
                    }
                    b.lastFitness = func(b.position);
                }
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
            public double loudness;


            public Bat(double[] position)
            {
                this.position = position;
                this.velocity = new double[position.Length];
            }


        }
    }

}