using System;
using System.Collections.Generic;
using DataStructures.Lib.Graphs;

namespace Algorithms.Lib.Graphs
{
    public static class BFS
    {
        //Performs BFS to find node with value
        //returns node with given value
        //returns null if value was not found in graph
        public static GraphNode<T> Search<T>(GraphNode<T> begining, T value)
        {
            System.Collections.Generic.Queue<GraphNode<T>> q = new System.Collections.Generic.Queue<GraphNode<T>>();
            HashSet<GraphNode<T>> visited = new HashSet<GraphNode<T>>();
            q.Enqueue(begining);

            while(q.Count != 0)
            {
                GraphNode<T> node = q.Dequeue();

                if(node.Value.Equals(value))
                    return node;


                if(!visited.Contains(node))
                {
                    visited.Add(node);
                    foreach(GraphNode<T> n in node.Neighbours)
                    {
                        q.Enqueue(n);
                    }
                }
            }
            return null;
        }
    }
}