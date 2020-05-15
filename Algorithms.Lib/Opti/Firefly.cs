using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.Opti
{
    using Utils;
    public class Firefly : IOptiAlg
    {
        private static Random rnd = new Random();
        public int generations = 1000;
        public int populationCount = 40;
        public double absorptionCoefficient = 1;
        public int dimension = 10;
        public double[] searchSpace = { -10.0, 10.0 };

        public static double[] attractivenessSpace = { 0.0, 1.0 };
        public double randomnessFactor = 0.2;

        public double[] Opti(Func<double[], double> func)
        {

            /*initialize n fireflies to random positions
                loop maxEpochs times
                for i := 0 to n-1
                    for j := 0 to n-1
                    if intensity(i) < intensity(j)
                        compute attractiveness
                        move firefly(i) toward firefly(j)
                        update firefly(i) intensity
                    end for
                    end for
                sort fireflies
                end loop
                return best position found
            */

            List<Fly> population = new List<Fly>();
            for (int i = 0; i < populationCount; i++)
            {
                Fly f = new Fly(rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1]));
                population.Add(f);
            }

            double[] bestPosition = rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1]);
            double best = func(bestPosition);



            for (int gen = 0; gen < generations; gen++)
            {
                for (int i = 0; i < populationCount; i++)
                {
                    for (int j = 0; j < populationCount; j++)
                    {
                        if (i == j)
                            continue;

                        //If j is better then i
                        if (func(population[j].position) < func(population[i].position))
                        {
                            double dist = CalculateAttractiveness(population[i], population[j]);
                            double[] candidatePosition = new double[dimension];
                            population[i].position.CopyTo(candidatePosition, 0);
                            //Move i closer to j
                            for (int dim = 0; dim < dimension; dim++)
                            {
                                candidatePosition[dim] += (population[j].position[dim] - population[i].position[dim])
                                 * dist;
                                candidatePosition[dim] += ((rnd.NextDouble() - 0.5) * randomnessFactor);

                                //Keep solution in bounds
                                if(candidatePosition[dim] < searchSpace[0])
                                    candidatePosition[dim] = searchSpace[0];

                                if(candidatePosition[dim] > searchSpace[1])
                                    candidatePosition[dim] = searchSpace[1];


                            }
                            
                            //Check if new pos is better then the old one
                            if (func(candidatePosition) < func(population[i].position))
                                population[i].position = candidatePosition;

                        }
                    }

                    double[] pos = population.Aggregate((x, y) => func(x.position) < func(y.position) ? x : y).position;
                    if (func(pos) < best)
                    {
                        bestPosition = pos;
                        best = func(bestPosition);
                    }
                }
            }
            return bestPosition;
        }

        private double CalculateDistance(double[] from, double[] target)
        {
            if (target.Length != from.Length)
                throw new ArgumentException("Bats dimensionality is not equal");

            //Calculate distance to the best bat using Cartesian metric
            double distance = 0;
            for (int i = 0; i < from.Length; i++)
            {
                distance += Math.Pow(from[i] - target[i], 2.0);
            }
            distance = Math.Sqrt(distance);
            return distance;
        }

        private double CalculateAttractiveness(Fly from, Fly to)
        {
            double dist = CalculateDistance(from.position, to.position);
            return 1.0 * Math.Exp(-absorptionCoefficient * dist * dist);
        }

        private class Fly
        {
            public double[] position;
            public double[] lastPosition;
            public Fly(double[] position)
            {
                this.position = position;
                this.lastPosition = position;
            }
        }
    }
}