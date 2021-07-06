using System.Windows;
using System.Windows.Media;

namespace CodeChallenge.DrawingProperties
{
    class TriangleDrawingProperties : IDrawingProperties, IFillable
    {
        public bool Fill { get; set; }
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Color Color { get; set; }
    }
}
