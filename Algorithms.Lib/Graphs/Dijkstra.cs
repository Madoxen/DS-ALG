using System.Collections.Generic;
using DataStructures.Lib.Graphs;
using System.Linq;
using System;

namespace Algorithms.Lib.Graphs
{
    public static class Dijkstra
    {
        public static List<GraphNode<T>> Perform<T>(GraphNode<T> beginning, GraphNode<T> target)
        {
            List<GraphNode<T>> verts = beginning.Flatten();

            Dictionary<GraphNode<T>, int> distances = new Dictionary<GraphNode<T>, int>();
            Dictionary<GraphNode<T>, GraphNode<T>> path = new Dictionary<GraphNode<T>, GraphNode<T>>();

            foreach (GraphNode<T> v in verts)
            {
                distances.Add(v, int.MaxValue);
                path.Add(v, null);
            }
            distances[beginning] = 0;
            path[beginning] = null;

            while (verts.Count != 0)
            {
                //Get node of minimum distance
                GraphNode<T> u = distances.Aggregate((x, y) => (x.Value < y.Value && verts.Contains(x.Key) && verts.Contains(y.Key)) ? x : y).Key;
                verts.Remove(u);

                    if (u == target)
                    break; //We found path to the target
                    

                foreach (GraphNode<T> neigh in u.Neighbours)
                {
                    if (!verts.Contains(neigh))
                        continue;

                    int alternativeDistance = distances[u] + u.Distances[neigh];
                    if (alternativeDistance < distances[neigh])
                    {
                        distances[neigh] = alternativeDistance;
                        path[neigh] = u;
                    }
                }
            }

            List<GraphNode<T>> result = new List<GraphNode<T>>();
            result.Add(target);
            GraphNode<T> current = target;
            //backpropagate path
            while (current != beginning)
            {
                current = path[current];
                result.Add(current);
            }
            result.Reverse();
            return result;
        }
    }
}