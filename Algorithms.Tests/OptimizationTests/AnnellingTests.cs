using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using Lib.Opti;

    [TestClass]
    public class AnneallingTests
    {
        [TestMethod]
        public void Test()
        {
            Annealing a = new Annealing(10000, 1000);
            a.dimensions = 10;
            IOptiTestFunc f = new SumSquares();
            a.searchSpace = f.SearchSpace;
            a.minVal = f.MinimumValue;
            double[] res = a.Opti(f.Func);
            double val = f.Func(res);

            Assert.AreEqual(f.MinimumValue, val, 5);

            a = new Annealing(10000, 1000);
            a.dimensions = 10;
            f = new Weierstrass();
            a.searchSpace = f.SearchSpace;
            a.minVal = f.MinimumValue;
            res = a.Opti(f.Func);
            val = f.Func(res);

            Assert.AreEqual(f.MinimumValue, val, 5);
        }

    }

}