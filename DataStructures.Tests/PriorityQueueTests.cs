using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lib;
using System;

namespace DataStructures.Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void EnqueueTest()
        {
            PriorityQueue<int> q = new PriorityQueue<int>(3, 1);
            q.Enqueue(1, 0);
            q.Enqueue(2, 0);
            q.Enqueue(3, 0);
        }


        [TestMethod]
        public void DequeueTest()
        {
            PriorityQueue<int> q = new PriorityQueue<int>(3, 1);
            q.Enqueue(1, 0);
            q.Enqueue(2, 0);
            q.Enqueue(3, 0);
            q.Dequeue();
            q.Dequeue();
            q.Dequeue();
        }

        [TestMethod]
        public void DequeueOrderingTest()
        {
            PriorityQueue<int> q = new PriorityQueue<int>(3, 3);
            q.Enqueue(1, 0);
            q.Enqueue(2, 1);
            q.Enqueue(3, 2);
            Assert.AreEqual(3, q.Dequeue());
            Assert.AreEqual(2, q.Dequeue());
            Assert.AreEqual(1, q.Dequeue());
        }


        [TestMethod]
        public void OvercapacityEnqueueTest()
        {
            PriorityQueue<int> q = new PriorityQueue<int>(1, 3);
            q.Enqueue(0, 1);
            Assert.ThrowsException<InvalidOperationException>(() => { q.Enqueue(1, 2); });
        }


        [TestMethod]
        public void PriorityOutOfBoundsTest()
        {
            PriorityQueue<int> q = new PriorityQueue<int>(2, 1);
            q.Enqueue(0, 0);
            Assert.ThrowsException<IndexOutOfRangeException>(() => { q.Enqueue(0, 2); });
        }

    }
}
