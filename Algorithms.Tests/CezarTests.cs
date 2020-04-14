using Algorithms.Lib.Encoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class CezarTests
    {
        [TestMethod]
        public void EncodeDecodeTest()
        {
            string original = "Give me the GEP gun";
            string encoded = Cezar.Encode(original, 4);
            Assert.AreEqual(original, Cezar.Decode(encoded, 4));
        }

    }

}