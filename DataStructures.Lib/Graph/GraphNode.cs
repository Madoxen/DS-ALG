using System.Collections.Generic;
using System.Linq;
namespace DataStructures.Lib.Graphs
{
    public class GraphNode<T>
    {
        List<GraphNode<T>> _neighbours = new List<GraphNode<T>>(); //neighbours list
        Dictionary<GraphNode<T>, int> _distances = new Dictionary<GraphNode<T>, int>();
        public T Value { get; set; }

        public GraphNode(T value)
        {
            Value = value;
        }

        public GraphNode()
        {
            Value = default(T);
        }

        public List<GraphNode<T>> Neighbours
        {
            get { return _neighbours; }
        }

        public Dictionary<GraphNode<T>, int> Distances
        {
            get { return _distances; }
        }

        public GraphNode<T> Add(T val)
        {
            GraphNode<T> n = new GraphNode<T>(val);
            Add(n);
            return n;
        }

        public GraphNode<T> Add(T val, int distance)
        {
            GraphNode<T> n = new GraphNode<T>(val);
            Add(new GraphNode<T>(val), distance);
            return n;
        }

        public void Add(GraphNode<T> neighbour)
        {
            _neighbours.Add(neighbour);
        }

        public void Add(GraphNode<T> neighbour, int distance)
        {
            Add(neighbour);
            _distances.Add(neighbour, distance);
        }

        public void AddTwoWay(GraphNode<T> neighbour)
        {
            neighbour.Add(this);
            this.Add(neighbour);
        }

        public void AddTwoWay(GraphNode<T> neighbour, int distance)
        {
            AddTwoWay(neighbour);
            _distances.Add(neighbour, distance);
            neighbour.Distances.Add(this, distance);
        }

        public GraphNode<T> AddTwoWay(T val)
        {
            GraphNode<T> node = new GraphNode<T>(val);
            AddTwoWay(node);
            return node;
        }

        public GraphNode<T> AddTwoWay(T val, int distance)
        {
            GraphNode<T> node = new GraphNode<T>(val);
            AddTwoWay(node, distance);
            return node;
        }

        public bool Remove(GraphNode<T> neighbour)
        {
            _distances.Remove(neighbour);
            return _neighbours.Remove(neighbour);
        }

        //Calls Remove on both this instance and neighbour instance
        public void RemoveTwoWay(GraphNode<T> neighbour)
        {
            _neighbours.Remove(neighbour);
            neighbour.Remove(this);
        }

        //Dereferences this node from all neighbouring nodes
        public void Dereference()
        {
            for (int i = 0; i < _neighbours.Count; i++)
            {
                if (_neighbours.Remove(_neighbours[i]))
                {
                    _neighbours[i].Remove(this);
                    i--; //dont forget to move i back so we can remove everything 
                }
            }
        }

        public List<GraphNode<T>> Flatten()
        {
            System.Collections.Generic.Queue<GraphNode<T>> q = new System.Collections.Generic.Queue<GraphNode<T>>();
            HashSet<GraphNode<T>> visited = new HashSet<GraphNode<T>>();
            q.Enqueue(this);

            while (q.Count != 0)
            {
                GraphNode<T> node = q.Dequeue();

                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    foreach (GraphNode<T> n in node.Neighbours)
                    {
                        q.Enqueue(n);
                    }
                }
            }
            return visited.ToList();
        }



        public GraphNode<T> this[int index]
        {
            get { return _neighbours[index]; }
            set
            {
                _neighbours[index] = value;
            }
        }


    }
}