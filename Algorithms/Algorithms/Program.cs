using System;
using Algorithms.PriorityQueue.Helpers;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialBoard = new[]
            {
                new[] {0, 1, 3},
                new[] {4, 2, 5},
                new[] {7, 8, 6}
            };
            var puzzleSolver = new PuzzleSolver(new Board(initialBoard));
            var stepsCount = puzzleSolver.Solve();
            
            Console.WriteLine(stepsCount);
            Console.ReadLine();
        }
    }
}