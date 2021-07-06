using CodeChallenge.Model.Coordinates;
using System;
using System.Drawing;

namespace CodeChallenge.Model.Shape
{
    public class Triangle : IShape, IFillable
    {
        public Triangle(CartesianPoint a, CartesianPoint b, CartesianPoint c, Color color, bool filled)
        {
            A = a;
            B = b;
            C = c;
            Color = color;
            Filled = filled;
        }
        public ShapeType Type => ShapeType.Triangle;

        public Color Color { get; }

        public CartesianPoint A { get; }

        public CartesianPoint B { get; }

        public CartesianPoint C { get; }

        public bool Filled { get; }

        public double MaxDimensionAbsolute => Math.Max(Math.Max(A.MaxDimensionAbsolute, B.MaxDimensionAbsolute), C.MaxDimensionAbsolute);
    }
}
