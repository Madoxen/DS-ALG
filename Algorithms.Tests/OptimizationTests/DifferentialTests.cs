using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using Lib.Opti;
    
    [TestClass]
    public class DifferentialTests
    {
        [TestMethod]
        public void Test()
        {
            Differential d = new Differential();
            IOptiTestFunc f = new HyperEllipsoid();
            double[] res = d.Opti(f.Func);
            double val = f.Func(res);
        }

    }

}