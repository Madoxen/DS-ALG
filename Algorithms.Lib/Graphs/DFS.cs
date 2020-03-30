using System;
using System.Collections.Generic;
using DataStructures.Lib.Graphs;

namespace Algorithms.Lib.Graphs
{
    public static class DFS
    {
        //Performs DFS to find node with value
        //returns node with given value
        //returns null if value was not found in graph
        public static GraphNode<T> Search<T>(GraphNode<T> begining, T value)
        {
            System.Collections.Generic.Stack<GraphNode<T>> stack = new System.Collections.Generic.Stack<GraphNode<T>>();
            HashSet<GraphNode<T>> visited = new HashSet<GraphNode<T>>();
            stack.Push(begining);

            while(stack.Count != 0)
            {
                GraphNode<T> node = stack.Pop();

                if(node.Value.Equals(value))
                    return node;


                if(!visited.Contains(node))
                {
                    visited.Add(node);
                    foreach(GraphNode<T> n in node.Neighbours)
                    {
                        stack.Push(n);
                    }
                }
            }

            return null;
        }
    }
}