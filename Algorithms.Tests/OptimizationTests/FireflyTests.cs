using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using Lib.Opti;
    [TestClass]
    public class FireflyTests
    {
        [TestMethod]
        public void Test()
        {
            Firefly fire = new Firefly();
            IOptiTestFunc f = new Weierstrass();
            fire.dimension = 10;
            fire.searchSpace = f.SearchSpace;
            double[] res = fire.Opti(f.Func);
            double val = f.Func(res);
            //Assert.AreEqual(f.MinimumValue, val, 5);

            fire = new Firefly();
            f = new SumSquares();
            fire.dimension = 10;
            fire.searchSpace = f.SearchSpace;
            res = fire.Opti(f.Func);
            val = f.Func(res);
            Assert.AreEqual(f.MinimumValue, val, 5);
        }

    }
}