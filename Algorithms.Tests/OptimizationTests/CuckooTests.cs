using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using Lib.Opti;
    [TestClass]
    public class CuckooTests
    {
        [TestMethod]
        public void Test()
        {
            Cuckoo c = new Cuckoo();
            IOptiTestFunc f = new Weierstrass();

            c.dimension = 10;
            c.searchSpace = f.SearchSpace;
            double[] res = c.Opti(f.Func);
            double val = f.Func(res);

            Assert.AreEqual(f.MinimumValue, val, 5);
        }

    }
}