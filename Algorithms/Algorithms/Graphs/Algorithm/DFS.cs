using System.Collections.Generic;
using Algorithms.Graphs.Structure;

namespace Algorithms.Graphs.Algorithm
{
    public class DFS
    {
        private readonly bool[] _visited; 
        private readonly int[] _edgeTo;
        private readonly int _origin;

        public DFS(Graph graph, int origin)
        {
            _origin = origin;
            _visited = new bool[graph.Size];
            _edgeTo = new int[graph.Size];

            RecursiveBuild(graph, origin);
        }

        private void RecursiveBuild(Graph graph, int v)
        {
            _visited[v] = true;
            foreach (var w in graph.Adjusted(v))
            {
                if (_visited[w])
                {
                    continue;
                }

                RecursiveBuild(graph, w);
                _edgeTo[w] = v;
            }
        }

        public bool HasPathTo(int v) => _visited[v];

        public List<int> PathTo(int v)
        {
            var path = new List<int>();
            if (!HasPathTo(v))
            {
                return path;
            }

            for (var i = v; i != _origin; i = _edgeTo[i])
            {
                path.Add(i);
            }
            path.Add(_origin);
            return path;
        }
    }
}