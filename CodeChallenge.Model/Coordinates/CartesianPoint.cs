using System;

namespace CodeChallenge.Model.Coordinates
{
    public class CartesianPoint
    {
        public CartesianPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; }
        public double Y { get; }

        public double MaxDimensionAbsolute => Math.Max(Math.Abs(X), Math.Abs(Y));
    }
}
