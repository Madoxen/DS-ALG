namespace Algorithms.Tests
{
    public class HyperEllipsoid : IOptiTestFunc
    {
        public double MinimumValue { get { return 0;} }


        private double[] searchSpace = new double[2] {-100.0, 100.0};
        public double[] SearchSpace {get {return searchSpace;}}

        public double Func(double[] input)
        {
            double result = 0;
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    result += input[j]*input[j];
                }
            }
            return result;
        }
    }

}