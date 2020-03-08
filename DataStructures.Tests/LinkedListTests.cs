using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lib;
using System;

namespace DataStructures.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        
        [TestMethod]
        public void AddTest()
        {
            LinkedList<int> l = new LinkedList<int>();
            l.Add(1);
            l.Add(2);
        }

        [TestMethod]
        public void RemoveTest()
        {
            LinkedList<int> l = new LinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Remove(0);
            Assert.AreEqual(l[0], 2);

            l.Add(3);
            l.Add(4);
            l.Add(5);
            l.Remove(2);
            
            Assert.AreEqual(l[0], 2);
            Assert.AreEqual(l[1], 3);
            Assert.AreEqual(l[2], 5);

            l.Remove(1);

            Assert.AreEqual(l[0], 2);
            Assert.AreEqual(l[1], 5);

            l.Remove(1);

            Assert.AreEqual(l[0], 2);

            l.Add(3);
            l.Add(4);

            Assert.AreEqual(l[0],2);
            Assert.AreEqual(l[1],3);
            Assert.AreEqual(l[2],4);
            
        }

        




    }
}
