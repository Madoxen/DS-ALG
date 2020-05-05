namespace Algorithms.Tests
{
    public interface IOptiTestFunc
    {
        double Func(double[] input);

        double MinimumValue {get;}
        double[] SearchSpace {get;}




       
    }

}