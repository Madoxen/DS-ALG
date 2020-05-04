namespace Algorithms.Tests
{
    public class HyperEllipsoid : IOptiTestFunc
    {
        public double MinimumValue { get { return 0;} }


        public double Func(double[] input)
        {
            double result = 0;
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 0; j < i; i++)
                {
                    result += input[j]*input[j];
                }
            }
            return result;
        }
    }

}