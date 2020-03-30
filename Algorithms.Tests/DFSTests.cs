using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Lib.Graphs;
using DataStructures.Lib.Graphs;


namespace Algorithms.Tests
{
    [TestClass]
    public class DFSTests
    {
        [TestMethod]
        public void TestDFS()
        {
            GraphNode<int> graphRoot = new GraphNode<int>(1);
            graphRoot.Add(2).Add(4);
            GraphNode<int> expected = graphRoot.Add(3).Add(5).Add(6);


            Assert.AreEqual(expected,DFS.Search(graphRoot,6)); 
        }


    }





}