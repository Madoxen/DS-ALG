using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using Lib.Opti;
    [TestClass]
    public class BeesTests
    {
        [TestMethod]
        public void Test()
        {
            Bees bee = new Bees();
            IOptiTestFunc f = new Weierstrass();
            bee.dimension = 10;
            bee.searchSpace = f.SearchSpace;
            double[] res = bee.Opti(f.Func);
            double val = f.Func(res);
            Assert.AreEqual(f.MinimumValue, val, 5);

            bee = new Bees();
            f = new SumSquares();
            bee.dimension = 10;
            bee.searchSpace = f.SearchSpace;
            res = bee.Opti(f.Func);
            val = f.Func(res);
            Assert.AreEqual(f.MinimumValue, val, 5);
        }

    }
}