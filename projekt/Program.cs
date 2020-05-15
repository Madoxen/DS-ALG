using System;
using Algorithms.Lib.Opti;

namespace projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Differential alg = new Differential();
            alg.dimension = 2;
            alg.searchSpace = new double[] {0.0, 50.0};
            double[] result = alg.Opti(func);
            double val = -func(result); //multiply by -1 to get real value (see note in func)
            
            Console.WriteLine("Value: " + val + " at ");
            for(int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]  + " ");
            }
        }



        static double func(double[] input)
        {
            double result = 0;
            for(int i = 0; i < input.Length; i++)
            {
                result += Math.Pow(2.0,input[i]);
            }
            return -Math.Pow(result,2.0); //Note: We use - here, to find maximum of this function
        }



    }
}
