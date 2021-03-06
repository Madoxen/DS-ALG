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
            IOptiTestFunc f = new SumSquares();
            d.dimension = 10;
            d.searchSpace = f.SearchSpace;
            double[] res = d.Opti(f.Func);
            double val = f.Func(res);

            Assert.AreEqual(f.MinimumValue, val, 5);

            d = new Differential();
            f = new Weierstrass();
            d.dimension = 10;
            d.searchSpace = f.SearchSpace;
            res = d.Opti(f.Func);
            val = f.Func(res);

            Assert.AreEqual(f.MinimumValue, val, 5);

        }

    }

}