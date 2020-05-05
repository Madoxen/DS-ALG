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
            Anneling a = new Anneling(1000000, 10);
            IOptiTestFunc f = new HyperEllipsoid();
            double[] res = a.Opti(f.Func);
            double val = f.Func(res);
        }

    }

}