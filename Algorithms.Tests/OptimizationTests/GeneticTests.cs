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
            double[] res = g.Opti(f.Func);
            double val = f.Func(res);
        }

    }
}