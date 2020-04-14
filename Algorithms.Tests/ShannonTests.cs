using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Lib.Compression;

namespace Algorithms.Tests
{
    [TestClass]
    public class ShannonTests
    {   
        [TestMethod]
        public void Test()
        {
            string original = "Do you like our owl?";
            ShannonFano f = new ShannonFano();
            string encoded = f.Encode(original);
            string decoded = f.Decode(encoded);
            Assert.AreEqual(original, decoded);
        }

    }

}