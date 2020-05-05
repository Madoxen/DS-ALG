using System;
using System.Collections.Generic;

namespace Algorithms.Lib.Opti
{
    public class Cuckoo : IOptiAlg
    {

        private static Random random = new Random();
        public int nestCount;
        public int inputDimension;
        public int maxGeneration;


        public Cuckoo() { }

        public Cuckoo(int nestCount, int inputDimension, int maxGeneration)
        {
            this.nestCount = nestCount;
            this.inputDimension = inputDimension;
            this.maxGeneration = maxGeneration;
        }




        public double[] Opti(Func<double[], double> func)
        {
            List<double[]> nests = new List<double[]>();
            //Generate nestCount nests
            for (int i = 0; i < nestCount; i++)
            {
                nests.Add(GenerateRandomNest(inputDimension));
            }
            //Perform search
            int generation = 0;
            while(generation < maxGeneration)
            {

            }
            return null;
        }

        private double[] GenerateRandomNest(int n)
        {
            double[] d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = random.NextDouble();
            }
            return d;
        }
    }

}