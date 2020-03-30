using System;
using Algorithms.Lib.Graphs;
using DataStructures.Lib.Graphs;
using System.Collections.Generic;


namespace staging
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphNode<char> root = new GraphNode<char>('a');
            var b = root.AddTwoWay('b', 2);
            var c = root.AddTwoWay('c', 1);
            var d = b.AddTwoWay('d', 4);
            c.AddTwoWay(d, 1);
            var e = b.AddTwoWay('e', 5);
            d.AddTwoWay(e, 3);

            var res = Floyd.Perform(root);
            List<GraphNode<char>> path = ReconstructPath(res, root, e);
            foreach (var p in path)
            {
                Console.WriteLine(p.Value);
            }

            foreach(var aa in res)
            {
                foreach(var bb in aa.Value)
                {
                    Console.Write(bb.Value?.Value + " ");
                }
                Console.WriteLine();
            }
        }


        static List<GraphNode<T>> ReconstructPath<T>(Dictionary<GraphNode<T>, Dictionary<GraphNode<T>, GraphNode<T>>> floyd, GraphNode<T> beginning, GraphNode<T> end)
        {
            List<GraphNode<T>> result = new List<GraphNode<T>>();
            if (floyd[beginning][end] == null) //if there is no path
                return null;

            GraphNode<T> curr = beginning;
            while (curr != end)
            {
                result.Add(curr);
                curr = floyd[curr][end];
            }
            result.Add(end);
            return result;
        }
    }
}
