using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Lib.Graphs;
using DataStructures.Lib.Graphs;


namespace Algorithms.Tests
{
    [TestClass]
    public class BFSTests
    {
        [TestMethod]
        public void TestBFS()
        {
            GraphNode<int> graphRoot = new GraphNode<int>(1);
            graphRoot.Add(2).Add(4);
            GraphNode<int> expected = graphRoot.Add(3).Add(5).Add(6);


            Assert.AreEqual(expected,BFS.Search(graphRoot,6)); 
        }


    }





}