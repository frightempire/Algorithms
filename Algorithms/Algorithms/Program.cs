using System;
using Algorithms.Graphs.Algorithm;
using Algorithms.Graphs.Structure;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph(9);
            graph.AddEdge(0,1); graph.AddEdge(0,2); graph.AddEdge(0,5); graph.AddEdge(0,6);
            graph.AddEdge(3,4); graph.AddEdge(3,5);
            graph.AddEdge(4,5); graph.AddEdge(4,6);
            graph.AddEdge(7,8);

            var dfs = new DFS(graph, 0);

            Console.WriteLine($"Path 0-3 : {string.Join(",", dfs.PathTo(3))}");
            Console.WriteLine($"Path 0-2 : {string.Join(",", dfs.PathTo(2))}");
            Console.WriteLine($"Path 0-4 : {string.Join(",", dfs.PathTo(4))}");
            Console.WriteLine($"Path 0-7 : {string.Join(",", dfs.PathTo(7))}");

            Console.ReadLine();
        }
    }
}