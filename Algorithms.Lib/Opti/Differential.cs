using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Lib.Opti
{

    public class Differential : IOptiAlg
    {
        private static Random rnd = new Random();

        public double[] searchSpace;
        public int iterCount = 5000;
        public int initialPopulation = 1000;
        public int dimension = 10;

        public double crossoverProbability = 0.5;
        public double differentialWeight = 1.0;


        public double[] Opti(Func<double[], double> func)
        {
            //https://en.wikipedia.org/wiki/Differential_evolution
            //initialize agent population
            List<double[]> pop = new List<double[]>();
            for (int i = 0; i < initialPopulation; i++)
            {
                pop.Add(GenerateRandomAgent(dimension));
            }

            //Perform algorithm
            for (int i = 0; i < iterCount; i++)
            {
                //For each agent in population
                for (int j = 0; j < pop.Count; j++)
                {
                    //Pick three distinct agents, that are distinct from "agent" as well
                    double[][] referenceAgents = PickReferenceAgents(pop, j);
                //    int dimensionIndex = rnd.Next(0, dimension);
                    double[] potential = new double[dimension];

                    //Compute potential new agent's position
                    for (int k = 0; k < dimension; k++)
                    {
                        double r = rnd.NextDouble();

                        if (r < crossoverProbability)
                            potential[k] = referenceAgents[0][k] + differentialWeight * (referenceAgents[1][k] - referenceAgents[2][k]);
                    }
                    if (func(potential) <= func(pop[j]))
                        pop[j] = potential;
                }
            }


            double[] bestAgent = pop[0];
            foreach (double[] agent in pop)
            {
                if (func(agent) <= func(bestAgent))
                    bestAgent = agent;
            }

            return bestAgent;
        }

        private double[] GenerateRandomAgent(int n)
        {
            double[] d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = rnd.NextDouble();
            }
            return d;
        }


        //Picks 3 reference agents that are unique and distinct from agent on AgentIndex in population
        private double[][] PickReferenceAgents(List<double[]> population, int AgentIndex)
        {
            if (population.Count < 4)
                throw new Exception("Constraint not satisfied: Population smaller than 4, algorithm cannot proceed");

            List<double[]> tempPop = new List<double[]>(population);
            double[][] result = new double[3][];
            for (int i = 0; i < 3; i++)
            {
                int index = rnd.Next(0, tempPop.Count);
                result[i] = tempPop[index];
                tempPop.RemoveAt(index);
            }
            return result;
        }
    }
}