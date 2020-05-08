using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    using Lib.Opti;
    
    [TestClass]
    public class AnnellingTests
    {
        [TestMethod]
        public void Test()
        {
            Anneling a = new Anneling(500000, 10000);
            a.dimensions = 10;
            IOptiTestFunc f = new HyperEllipsoid();
            a.searchSpace = f.SearchSpace;
            double[] res = a.Opti(f.Func);
            double val = f.Func(res);
            
            Assert.AreEqual(f.MinimumValue, val, 5);
        }

    }

}