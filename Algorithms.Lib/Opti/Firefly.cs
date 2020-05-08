using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.Opti
{
    using Utils;
    public class Firefly : IOptiAlg
    {

        private static Random rnd = new Random();
        public int generations = 20000;
        public int populationCount = 100;
        public double absorptionCoefficient = 1;
        public int dimension = 10;
        public double[] searchSpace = { -10.0, 10.0 };

        public static double[] attractivenessSpace = { 0.0, 1.0 };
        public double randomnessFactor = 0.2;

        public double[] Opti(Func<double[], double> func)
        {
            List<Fly> population = new List<Fly>();
            for (int i = 0; i < populationCount; i++)
            {
                population.Add(new Fly(rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1])));
            }

            double[] bestPosition = rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1]);
            double best = func(bestPosition);


            for (int gen = 0; gen < generations; gen++)
            {
                for (int i = 0; i < populationCount; i++)
                {
                    for (int j = 0; j < populationCount; j++)
                    {
                        //If j is better then i
                        if (func(population[j].position) < func(population[i].position))
                        {
                            //Move i closer to j
                            for (int dim = 0; dim < dimension; dim++)
                            {
                                population[i].position[dim] += (population[j].position[dim] - population[i].position[dim])
                                 * CalculateAttractiveness(population[j], population[i]);
                                population[i].position[dim] += ((rnd.NextDouble() - 0.5) * randomnessFactor);

                                //Keep bounds intact
                                if (population[i].position[dim] < searchSpace[0])
                                    population[i].position[dim] = rnd.RandomNormal(searchSpace[0], searchSpace[1], 10);
                                if (population[i].position[dim] > searchSpace[1])
                                    population[i].position[dim] = rnd.RandomNormal(searchSpace[0], searchSpace[1], 10);
                            }
                        }
                    }
                }

                double[] pos = population.Aggregate((x, y) => func(x.position) < func(y.position) ? x : y).position;
                if (func(pos) < best)
                {
                    bestPosition = pos;
                    best = func(bestPosition);
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
            return from.attractiveness * Math.Exp(-absorptionCoefficient * dist * dist);
        }

        private class Fly
        {
            public double attractiveness; //Also called Beta-0
            public double[] position;

            public Fly(double[] position)
            {
                this.position = position;
                attractiveness = rnd.NextDouble();
            }
        }

    }


}