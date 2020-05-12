using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using Lib.Opti;
    [TestClass]
    public class SwarmTests
    {
        [TestMethod]
        public void Test()
        {
            Swarm g = new Swarm();
            IOptiTestFunc f = new Weierstrass();
            g.dimension = 10;
            g.searchSpace = f.SearchSpace;
            double[] res = g.Opti(f.Func);
            double val = f.Func(res);
            Assert.AreEqual(f.MinimumValue, val, 5);

            g = new Swarm();
            f = new SumSquares();
            g.dimension = 10;
            g.searchSpace = f.SearchSpace;
            res = g.Opti(f.Func);
            val = f.Func(res);
            Assert.AreEqual(f.MinimumValue, val, 5);
        }

    }

}