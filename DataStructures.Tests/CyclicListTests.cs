using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lib;
using System.Diagnostics;
using System;

namespace DataStructures.Tests
{
    [TestClass]
    public class CyclicListTest
    {


        [TestMethod]
        public void AddTest()
        {
            CyclicList<int> c = new CyclicList<int>();
            c.Add(1);
            c.Add(2);
            c.Add(3);
        }

        [TestMethod]
        public void GetTest()
        {
            CyclicList<int> c = new CyclicList<int>();
            c.Add(1);
            c.Add(2);
            c.Add(3);

            
            Assert.AreEqual(c[0],1);
            Assert.AreEqual(c[1],2);
            Assert.AreEqual(c[2],3);
            Assert.AreEqual(c[3],1);
            Assert.AreEqual(c[4],2);
            Assert.AreEqual(c[5],3);
        }

        [TestMethod]
        public void SetTest()
        {
            CyclicList<int> c = new CyclicList<int>();
            c.Add(1);
            c.Add(2);
            c.Add(3);


            c[3] = 2;
            c[4] = 3;

            
            Assert.AreEqual(c[0],2);
            Assert.AreEqual(c[1],3);
            Assert.AreEqual(c[2],3);
            Assert.AreEqual(c[3],2);
            Assert.AreEqual(c[4],3);
            Assert.AreEqual(c[5],3);
        }

        [TestMethod]
        public void RemoveTest()
        {
            CyclicList<int> c = new CyclicList<int>();
            c.Add(1);
            c.Add(2);
            c.Add(3);

            c.Remove(1);

            Assert.AreEqual(c[0],1);
            Assert.AreEqual(c[1],3);
            Assert.AreEqual(c[2],1);
            Assert.AreEqual(c[3],3);
            
        }
        
        [TestMethod]
        public void HeadRemovalTest()
        {
            CyclicList<int> c = new CyclicList<int>();
            c.Add(1);
            c.Add(2);
            c.Add(3);

            c.Remove(0);
            Debug.WriteLine(c[0].ToString() + c[1].ToString() + c[2].ToString());

            Assert.AreEqual(c[0], 2);
            Assert.AreEqual(c[1], 3);
            Assert.AreEqual(c[2], 2);
            Assert.AreEqual(c[3], 3);

            c.Remove(0);
            Assert.AreEqual(3, c[0]);
            c.Remove(0);
            Assert.ThrowsException<Exception>(() => {Debug.WriteLine(c[0]); });
        }


    }
}