namespace Algorithms.Tests
{
    public class SumSquares : IOptiTestFunc
    {
        public double MinimumValue { get { return 0;} }

        public double Func(double[] input)
        {
            double result = 0;
            for(int i = 0; i < input.Length; i++)
            {
                result += i * input[i] * input[i];
            }
            return result;
        }
    }


}