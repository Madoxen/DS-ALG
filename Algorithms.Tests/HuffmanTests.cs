using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Lib;
using Algorithms.Lib.Compression;
using System.Linq;
using System.Text;
using System;

namespace Algorithms.Tests
{
    [TestClass]
    public class HuffmanTests
    {   
        [TestMethod]
        public void WorkingTest()
        {
            Huffman huffman = new Huffman();
            string code = huffman.Encode(Encoding.UTF8.GetBytes("I watched c-beams glitter in the dark near the tannhauser gate"));
            string decoded = huffman.Decode(code);
        }
    }

}