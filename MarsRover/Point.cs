namespace MarsRover
{
    public record Point(ushort X, ushort Y)
    {
        public static Point operator +(Point a, Point b)
        {
            return new Point((ushort) (a.X + b.X), (ushort) (a.Y + b.Y));
        }
    }
}
