using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lib;
using System;

namespace DataStructures.Tests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void EnqueueTest()
        {
            Queue<int> q = new Queue<int>(3);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
        }

        [TestMethod]
        public void DequeueTest()
        {
            Queue<int> q = new Queue<int>(3);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Dequeue(); q.Dequeue(); q.Dequeue();
        }

        [TestMethod]
        public void InvalidDequeueTest()
        {
            Queue<int> q = new Queue<int>(3);
            Assert.ThrowsException<InvalidOperationException>(() => { q.Dequeue(); });
        }

        [TestMethod]
        public void InvalidEnqueueTest()
        {
            Queue<int> q = new Queue<int>(1);
            q.Enqueue(1);
            Assert.ThrowsException<InvalidOperationException>(() => { q.Enqueue(2); });
        }

        [TestMethod]
        public void CircularQueueTest()
        {
            Queue<int> q = new Queue<int>(3);

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Assert.AreEqual(1, q.Dequeue());
            q.Enqueue(4);
            Assert.AreEqual(2, q.Dequeue());
            Assert.AreEqual(3, q.Dequeue());
            Assert.AreEqual(4, q.Dequeue());
            
        }
    }
}
