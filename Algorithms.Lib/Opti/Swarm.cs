using System;
using System.Collections.Generic;
using System.Linq;


namespace Algorithms.Lib.Opti
{
    using Utils;


    public class Swarm : IOptiAlg
    {
        private static Random rnd = new Random();
        //Fancy math stuff
        public double[] searchSpace = { -10.0, 10.0 };
        public int dimension = 10;


        public int interCount = 10000;
        public int particleCount = 100;

        public double velocityFactor = 0.5;
        public double bestPositionFactor = 0.75;
        public double bestSwarmPositionFactor = 2;


        public double[] Opti(Func<double[], double> func)
        {
            //Create initial particle population
            List<Particle> particles = new List<Particle>();
            double[] bestSwarmPosition = rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1]);


            for (int i = 0; i < particleCount; i++)
            {
                particles.Add(new Particle(rnd.GenerateRandomArray(dimension, searchSpace[0], searchSpace[1]),
                rnd.GenerateRandomArray(dimension, -1.0, 1.0)));

                if (func(particles.Last().bestPosition) < func(bestSwarmPosition))
                {
                    bestSwarmPosition = particles.Last().bestPosition;
                }
            }


            //perform
            for (int i = 0; i < interCount; i++)
            {
                foreach (Particle p in particles)
                {
                    for (int dim = 0; dim < dimension; dim++)
                    {
                        double randomPositionFactor = rnd.NextDouble();
                        double randomSwarmFactor = rnd.NextDouble();

                        //Update velocity
                        p.velocity[dim] = (p.velocity[dim] * velocityFactor) + bestPositionFactor * randomPositionFactor * (p.bestPosition[dim] - p.position[dim]) +
                        bestSwarmPositionFactor * randomSwarmFactor * (bestSwarmPosition[dim] - p.position[dim]);
                    }


                    //update position
                    for (int dim = 0; dim < dimension; dim++)
                    {
                        p.position[dim] += p.velocity[dim];
                    }

                    if (func(p.position) < func(p.bestPosition))
                        p.bestPosition = p.position;

                    if (func(p.position) < func(bestSwarmPosition))
                        bestSwarmPosition = p.position;
                }
            }
            return bestSwarmPosition;
        }



        private class Particle
        {
            public double[] velocity;
            public double[] position;
            public double[] bestPosition;

            public Particle(double[] position, double[] velocity)
            {
                this.position = position;
                this.velocity = velocity;
                bestPosition = position;
            }
        }

    }
}