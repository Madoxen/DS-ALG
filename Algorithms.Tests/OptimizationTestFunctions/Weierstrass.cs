using System;

namespace Algorithms.Tests
{
    public class Weierstrass : IOptiTestFunc
    {
        public double MinimumValue { get { return 0; } }

        private double[] searchSpace = new double[2] { -10.0, 10.0 };
        public double[] SearchSpace { get { return searchSpace; } }


        public double Func(double[] input)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += Math.Pow(Math.Abs(input[i] + 0.5), 2.0);
            }
            return result;
        }
    }


}