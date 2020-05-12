using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using Lib.Opti;
    [TestClass]
    public class BatsTests
    {
        [TestMethod]
        public void Test()
        {
            Bats b = new Bats();
            IOptiTestFunc f = new Weierstrass();
            b.dimension = 10;
            b.searchSpace = f.SearchSpace;
            double[] res = b.Opti(f.Func);
            double val = f.Func(res);

           Assert.AreEqual(f.MinimumValue, val, 5);

            b = new Bats();
            f = new SumSquares();
            b.dimension = 10;
            b.searchSpace = f.SearchSpace;
            res = b.Opti(f.Func);
            val = f.Func(res);

            Assert.AreEqual(f.MinimumValue, val, 5);
        }

    }
}