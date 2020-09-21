using System.Collections.Generic;

namespace Algorithms.Graphs.Structure
{
    public class Graph
    {
        private readonly Dictionary<int, HashSet<int>> _adjust = new Dictionary<int, HashSet<int>>();

        public Graph(int size)
        {
            Size = size;
            for (var i = 0; i < size; i++)
            {
                _adjust[i] = new HashSet<int>();
            }
        }

        public int Size { get; }

        public void AddEdge(int v, int w)
        {
            _adjust[v].Add(w);
            _adjust[w].Add(v);
        }

        public HashSet<int> Adjusted(int v)
        {
            return _adjust.ContainsKey(v) ? _adjust[v] : new HashSet<int>();
        }
    }
}