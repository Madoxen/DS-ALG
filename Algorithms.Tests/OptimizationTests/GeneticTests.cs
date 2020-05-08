using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using Lib.Opti;
    [TestClass]
    public class GeneticTests
    {
        [TestMethod]
        public void Test()
        {
            Genetic g = new Genetic();
            IOptiTestFunc f = new Weierstrass();
            g.dimension = 10;
            g.searchSpace = f.SearchSpace;
            double[] res = g.Opti(f.Func);
            double val = f.Func(res);
            Assert.AreEqual(f.MinimumValue, val, 5);

            g = new Genetic();
            f = new HyperEllipsoid();
            g.dimension = 10;
            g.searchSpace = f.SearchSpace;
            res = g.Opti(f.Func);
            val = f.Func(res);
            Assert.AreEqual(f.MinimumValue, val, 5);
        }

    }
}