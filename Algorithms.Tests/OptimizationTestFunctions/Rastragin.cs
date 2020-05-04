using System;
namespace Algorithms.Tests
{
    public class Rastragin : IOptiTestFunc
    {
        public Rastragin() { }

        public double MinimumValue { get { return 0;} }


        public double Func(double[] input)
        {
            double result = 10.0 * input.Length;

            for (int i = 0; i < input.Length; i++)
            {
                result += (input[i] * input[i]) - 10.0 * Math.Cos(2.0 * Math.PI * input[i]);
            }
            return result;
        }
    }
}