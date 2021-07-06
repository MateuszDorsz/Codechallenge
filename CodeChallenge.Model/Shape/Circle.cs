using CodeChallenge.Model.Coordinates;
using System.Drawing;

namespace CodeChallenge.Model.Shape
{
    public class Circle : IShape, IFillable
    {
        public Circle(CartesianPoint center, double radius, Color color, bool filled)
        {
            Center = center;
            Radius = radius;
            Color = color;
            Filled = filled;
        }
        public ShapeType Type => ShapeType.Circle;

        public Color Color { get; }

        public CartesianPoint Center { get; }

        public double Radius { get; }

        public bool Filled { get; }

        public double MaxDimensionAbsolute => Center.MaxDimensionAbsolute + Radius;
    }
}
