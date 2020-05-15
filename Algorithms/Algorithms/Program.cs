using System;
using Algorithms.Percolation;
using Algorithms.Percolation.Algorithm;
using Algorithms.Percolation.Helpers;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var percolator = new Percolator(14,
                new WquWithPathCompressionConnector(),
                new WquWithCompressionPathTilesGenerator(),
                new RandomProvider(),
                new SquareMatrixOperations());

            var openTiles = percolator.BeginPercolation();

            Console.WriteLine();
            Console.WriteLine($"Open tiles : {openTiles}");

            Console.ReadLine();
        }
    }
}