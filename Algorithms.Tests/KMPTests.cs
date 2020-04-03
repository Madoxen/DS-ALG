using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Lib.Text;


namespace Algorithms.Tests
{
    [TestClass]
    public class KMPTests
    {
        [TestMethod]
        //Tests if KMP just passes by
        public void RunTest()
        {
            string s = " ABC ABCDAB ABCDABCDABDE";
            string pattern = "ABCDABD";
            KMP.Find(pattern, s);
        }

        //Tests if KMP returns correct index on human made example
        [TestMethod]
        public void TestIndex()
        {
            string s = "ABC ABCDAB ABCDABCDABDE";
            string pattern = "ABCDABD";
            Assert.AreEqual(15,KMP.Find(pattern, s));
        }
    }


}