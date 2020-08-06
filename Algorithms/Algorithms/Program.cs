using System;
using Algorithms.Trees.Algorithm;
using Algorithms.Trees.Helpers;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var twoDimensionalTree = new TwoDimensionalTree();
            twoDimensionalTree.Add(new Point(0,0));
            twoDimensionalTree.Add(new Point(10,10));
            twoDimensionalTree.Add(new Point(40,40));
            twoDimensionalTree.Add(new Point(40,60));
            twoDimensionalTree.Add(new Point(80,80));
            twoDimensionalTree.Add(new Point(20,100));

            var rectangleIntersections = twoDimensionalTree.RectangleSearch(new Rectangle(20, 30, 50, 70));
            var closestPoint = twoDimensionalTree.NearestNeighborSearch(new Point(60, 40));

            Console.WriteLine(string.Join("| ", rectangleIntersections));
            Console.WriteLine($"Closest point : {closestPoint}");
            Console.ReadLine();
        }
    }
}