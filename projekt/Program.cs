using System;
using Algorithms.Lib.Opti;

namespace projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Differential alg = new Differential()
            {
                iterCount = 5000,
                initialPopulation = 1000,
                crossoverProbability = 0.5,
                differentialWeight = 1.0,
                dimension = 2,
                searchSpace = new double[] { 0.0, 50.0 },
            };
           
            Console.WriteLine("Optimizing...");
            double[] result = alg.Opti(func);
            double val = -func(result); //multiply by -1 to get real value (see note in func)

            Console.WriteLine("Value: " + val + " at ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
        }


        /// <summary>
        /// Function that we want to maximize
        /// </summary>
        /// <param name="input">n dimensional input</param>
        /// <returns>value at input</returns>
        static double func(double[] input)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += Math.Pow(2.0, input[i]);
            }
            return -Math.Pow(result, 2.0); //Note: We use - here, to find maximum of this function
        }



    }
}
