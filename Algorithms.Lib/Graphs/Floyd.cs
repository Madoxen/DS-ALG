using DataStructures.Lib.Graphs;
using System;
using System.Collections.Generic;


namespace Algorithms.Lib.Graphs
{
    public static class Floyd
    {
        public static Dictionary<GraphNode<T>, Dictionary<GraphNode<T>, GraphNode<T>>> Perform<T>(GraphNode<T> root)
        {
            List<GraphNode<T>> verts = root.Flatten();

            Dictionary<GraphNode<T>, Dictionary<GraphNode<T>, double>> distances = new Dictionary<GraphNode<T>, Dictionary<GraphNode<T>, double>>();
            Dictionary<GraphNode<T>, Dictionary<GraphNode<T>, GraphNode<T>>> next = new Dictionary<GraphNode<T>, Dictionary<GraphNode<T>, GraphNode<T>>>();
            foreach (GraphNode<T> v in verts)
            {
                distances.Add(v, new Dictionary<GraphNode<T>, double>());
                next.Add(v, new Dictionary<GraphNode<T>, GraphNode<T>>());
                foreach (GraphNode<T> v2 in verts)
                {
                    distances[v].Add(v2, double.PositiveInfinity);
                    next[v].Add(v2, null);
                }

            }

            foreach (GraphNode<T> v in verts)
            {
                foreach (GraphNode<T> neighbour in v.Neighbours)
                {
                    distances[v][neighbour] = v.Distances[neighbour];
                    next[v][neighbour] = neighbour;
                }
                distances[v][v] = 0;
                next[v][v] = v;
            }

            foreach (GraphNode<T> i in verts)
            {
                foreach (GraphNode<T> j in verts)
                {
                    foreach (GraphNode<T> k in verts)
                    {
                        if (distances[j][k] > distances[j][i] + distances[i][k])
                        {
                            distances[j][k] = distances[j][i] + distances[i][k];
                            next[j][k] = next[j][i];
                        }
                    }
                }
            }
            return next;
        }
    }



}