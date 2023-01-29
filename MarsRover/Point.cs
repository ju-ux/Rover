﻿namespace MarsRover
{
    public record Point(int X, int Y)
    {
        public static Point operator +(Point a, Point b)
        {
            return new Point((a.X + b.X), (a.Y + b.Y));
        }
    }
}
