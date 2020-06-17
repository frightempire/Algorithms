using System.Collections.Generic;
using System.Linq;
using Algorithms.Sorting.Algorithm;
using Algorithms.Sorting.Helpers;

namespace Algorithms.Sorting
{
    public class LineBuilder
    {
        public int Get4PointLineSegmentsCount(List<Point> points)
        {
            Merge<Point>.Sort(points.ToArray());
            var count = 0;
            for (var i = 0; i < points.Count-1; i++)
            {
                var point = points[i];
                var slopes = GetSlopesForPoint(point, points.GetRange(i+1, points.Count-i-1)).ToArray();
                Merge<double>.Sort(slopes);
                count += slopes.GroupBy(s => s).Count(g => g.Count() >= 3);
            }
            return count;
        }

        private List<double> GetSlopesForPoint(Point originPoint, List<Point> points)
        {
            var slopes = new List<double>();
            foreach (var point in points)
            {
                slopes.Add(originPoint.SlopeTo(point));
            }
            return slopes;
        }
    }
}