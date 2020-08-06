namespace Algorithms.Trees.Helpers
{
    public class Rectangle
    {
        public Rectangle(double minX, double minY, double maxX, double maxY)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
        }

        public double MinX { get; }

        public double MinY { get; }

        public double MaxX { get; }

        public double MaxY { get; }

        public bool Contains(Point point) => point.X <= MaxX && point.X >= MinX && point.Y <= MaxY && point.Y >= MinY;
    }
}