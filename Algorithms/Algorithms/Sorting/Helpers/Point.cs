using System;

namespace Algorithms.Sorting.Helpers
{
    public class Point : IComparable
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public int CompareTo(object obj)
        {
            var pointToCompareWith = (Point)obj;
            return  Y < pointToCompareWith.Y ? -1 :
                    Y == pointToCompareWith.Y ? X < pointToCompareWith.X ? -1 :
                    X == pointToCompareWith.X ? 0 : 1 : 1;
        }

        public double SlopeTo(Point point) => (double) (point.Y - Y) / (point.X - X);

        public override string ToString() => $"X : {X}, Y : {Y}";
    }
}