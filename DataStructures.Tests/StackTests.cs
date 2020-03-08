using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lib;
using System;

namespace DataStructures.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void RemovalTest()
        {
            Stack<int> stack = new Stack<int>(10);
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void PeekTest()
        {

            Stack<int> stack = new Stack<int>(10);
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(2, stack.Peek());
            Assert.AreEqual(2, stack.Peek());
            Assert.AreEqual(2, stack.Count);

        }


        [TestMethod]
        public void RemovalCapacityExceptionTest()
        {
            Stack<int> stack = new Stack<int>(1);
            stack.Push(1);
            stack.Pop();
            Assert.ThrowsException<InvalidOperationException>(() => { stack.Pop(); });
        }

        [TestMethod]
        public void PushCapacityExceptionTest()
        {
            Stack<int> stack = new Stack<int>(1);
            stack.Push(1);
            Assert.ThrowsException<InvalidOperationException>(() => { stack.Push(2); });
        }



    }
}
