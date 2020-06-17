using System;
using System.Collections.Generic;
using Algorithms.Sorting;
using Algorithms.Sorting.Helpers;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var lineBuilder = new LineBuilder();
            var points = new List<Point>
            {
                new Point(1, 1),
                new Point(2, 1), new Point(2, 2), new Point(2, 3), new Point(2, 4), new Point(2, 5),
                new Point(3, 2), new Point(3, 3),
                new Point(4, 2), new Point(4, 4)
            };

            Console.WriteLine(lineBuilder.Get4PointLineSegmentsCount(points));
            Console.ReadLine();
        }
    }
}