using System;

namespace Algorithms.Tests
{
    public class StyblinskiTang : IOptiTestFunc
    {
        public double MinimumValue { get; private set; }

        public void SetMinimumValue(int n)
        {
            MinimumValue = (double)n * -39.2;
        }



        private double[] searchSpace = new double[2] { -10.0, 10.0 };
        public double[] SearchSpace { get { return searchSpace; } }


        public StyblinskiTang() { }
        public StyblinskiTang(int n) { SetMinimumValue(n); }

        public double Func(double[] input)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += Math.Pow(input[i], 4.0) - (16.0 * input[i] * input[i]) + (5.0 * input[i]);
            }
            return 0.5 * result;
        }
    }


}