using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Lib.Graphs;
using Algorithms.Lib.Graphs;


namespace Algorithms.Tests
{

    [TestClass]
    public class DijkstraTests
    {
        [TestMethod]
        public void TestDijkstra()
        {
            GraphNode<char> root = new GraphNode<char>('a');
            var b = root.AddTwoWay('b',2);
            var c = root.AddTwoWay('c',1);
            var d = b.AddTwoWay('d',4);
            c.AddTwoWay(d,1);
            var e =  b.AddTwoWay('e',5);
            d.AddTwoWay(e,3);

            Dijkstra.Perform(root,e);



        }
    }

}