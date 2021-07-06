using CodeChallenge.Model.Conversion;
using CodeChallenge.Model.Coordinates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CodeChallenge.Model.Shape
{
    public class Line : IShape
    {
        internal Line(CartesianPoint a, CartesianPoint b, Color color)
        {
            A = a;
            B = b;
            Color = color;
        }

        public ShapeType Type => ShapeType.Line;

        public Color Color { get; }

        public CartesianPoint A { get; }

        public CartesianPoint B { get; }

        public double MaxDimensionAbsolute => Math.Max(A.MaxDimensionAbsolute, B.MaxDimensionAbsolute);
    }
}
