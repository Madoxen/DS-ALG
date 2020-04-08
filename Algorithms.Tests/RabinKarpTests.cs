using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Lib.Text;

namespace Algorithms.Tests
{
    [TestClass]
    public class RabinKarpTests
    {
        [TestMethod]
        public void SimplePatternSearchTest()
        {
            KarpRabin.Find("I've seen things, you people wouldnt believe", "people");
        }


         [TestMethod]
        public void PatternSearchTest()
        {
            Assert.AreEqual(22,KarpRabin.Find("I've seen things, you people wouldnt believe", "people"));
        }

    }

}