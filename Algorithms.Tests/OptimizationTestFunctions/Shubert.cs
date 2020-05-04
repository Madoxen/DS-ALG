using System;

namespace Algorithms.Tests
{
    public class Shubert : IOptiTestFunc
    {
        public double MinimumValue { get { return -186.7;} }

        public double Func(double[] input)
        {
            double result = 1;
            for(int i = 0; i < input.Length; i++)
            {
                double temp = 0;
                for(int j = 0; j < 5; j++)
                {
                     temp += (double)j * Math.Cos((j+1)*input[i]);
                }
                result *= temp;
            }
            return result;
        }
    }
}