using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Lib.Text;

namespace Algorithms.Tests
{
    [TestClass]
    public class BoyerMooreTests
    {
        [TestMethod]
        public void TestFind()
        {
            BoyerMoore finder = new BoyerMoore("bad");
            string text = "It’s too bad she won’t live. But then again, who does?";
            Assert.AreEqual(9, finder.Find(text));
        }
    }
}