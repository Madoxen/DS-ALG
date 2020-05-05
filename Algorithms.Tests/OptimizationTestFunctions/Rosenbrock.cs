
using System;

namespace Algorithms.Tests
{
    public class Rosenbrock : IOptiTestFunc
    {
        public double MinimumValue { get { return 0; } }



        private double[] searchSpace = new double[2] { -100.0, 100.0 };
        public double[] SearchSpace { get { return searchSpace; } }

        public double Func(double[] input)
        {
            double result = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                result += 100.0 * Math.Pow(input[i + 1] - (input[i] * input[i]), 2.0) + Math.Pow(input[i] - 1.0, 2.0);
            }
            return result;
        }
    }

}