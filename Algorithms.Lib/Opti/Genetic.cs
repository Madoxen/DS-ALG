using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.Opti
{
    public class Genetic : IOptiAlg
    {
        private static Random rnd = new Random();
        //Fancy math stuff
        public double[] searchSpace = { -10.0, 10.0 };
        public int dimension = 10;


        public int generationCount = 10000; //How much generations to simulate
        public int populationCount = 1000; //Desired population count
        public double populationSurvivalRate = 0.3; //percent of population that wont die and will later reproduce
        public double mutationChance = 0.2; //Chance of mutation of one critter
        public double mutationPower = 0.3; // Mutation change multiplier, takes current value multiplies it and adds it to current value
        public double crossoverRatio = 0.5; //Chance of information of better parent / worse parent


        public double[] Opti(Func<double[], double> func)
        {
            List<Critter> population = new List<Critter>();
            for (int i = 0; i < populationCount; i++)
            {
                population.Add(new Critter(GenerateRandomArray(dimension, searchSpace[0], searchSpace[1])));
            }


            //Go through generations
            for (int i = 0; i < generationCount; i++)
            {
                //1. Selection categorize with fitness (in our case we check if objective function is smaller)
                AssignFitness(population, func);
                population = population.OrderBy(x => x.fitness).ToList();
                //Cut population according to populationSurvivalRate
                KillPop(population);


                List<Critter> children = new List<Critter>();
                //Crossover pops until pop limit is reached 
                while (children.Count + population.Count < populationCount)
                {
                    //Choose two random critters from current pool
                    Critter male = population[rnd.Next(0, population.Count)];
                    Critter female = population[rnd.Next(0, population.Count)];

                    //Crossover
                    children.Add(Crossover(male, female));
                }


                //Add children to global population pool
                population.AddRange(children);
                children.Clear();

                //Pass for mutation
                foreach (Critter c in population)
                {
                    //Roll for mutation!
                    double roll = rnd.NextDouble();
                    if (roll < mutationChance)
                        Mutate(c);
                }
            }


            //After generations and generations it's time to choose a winner
            AssignFitness(population, func); 
            population = population.OrderBy(x => x.fitness).ToList();
            return population[0].genetics;
        }

        private void AssignFitness(List<Critter> population, Func<double[], double> func)
        {
            // Selection categorize with fitness (in our case we check if objective function is smaller)
            for (int j = 0; j < population.Count; j++)
            {
                population[j].fitness = func(population[j].genetics);
            }

        }


        private double[] GenerateRandomArray(int n, double from, double to)
        {
            double[] d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = rnd.NextDouble() * (to - from) + from;
            }
            return d;
        }


        //Changes parameters of this critter
        private void Mutate(Critter critter)
        {
            for (int i = 0; i < critter.genetics.Length; i++)
            {
                critter.genetics[i] += critter.genetics[i] * mutationPower * (rnd.NextDouble() - 0.5);
            }
        }

        /// <summary>
        /// Crossesover male and female, exchanging their information
        /// </summary>
        /// <param name="male"></param>
        /// <param name="female"></param>
        private Critter Crossover(Critter male, Critter female)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < dimension; i++)
            {
                indexes.Add(i);
            }
            List<int> maleIndexes = new List<int>();
            List<int> femaleIndexes = new List<int>();

            //Choose random indexes for first parent
            for (int i = 0; i < dimension * crossoverRatio; i++)
            {
                int chosenIndex = rnd.Next(0, indexes.Count);
                maleIndexes.Add(indexes[chosenIndex]);
                indexes.RemoveAt(chosenIndex);
            }

            //left indexes are chosen female indexes
            femaleIndexes = new List<int>(indexes);

            //Now when we have all indexes, recombine them
            double[] childGenetics = new double[dimension];
            foreach (int index in maleIndexes)
            {
                childGenetics[index] = male.genetics[index];
            }
            foreach (int index in femaleIndexes)
            {
                childGenetics[index] = female.genetics[index];
            }

            return new Critter(childGenetics);
        }



        /// <summary>
        /// Only the strongest will survive!
        /// </summary>
        /// <param name="population">ORDERED by fitness collection of critters</param>
        private void KillPop(List<Critter> population)
        {
            int index = (int)((double)population.Count * populationSurvivalRate);
            population.RemoveRange(index, population.Count - index);
        }


        private class Critter
        {
            public double[] genetics;
            public double fitness;

            public Critter(double[] genetics)
            {
                this.genetics = genetics;
            }
        }
    }


}