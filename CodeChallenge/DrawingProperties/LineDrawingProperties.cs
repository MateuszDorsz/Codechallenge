using System.Windows;
using System.Windows.Media;

namespace CodeChallenge.DrawingProperties
{
    class LineDrawingProperties : IDrawingProperties
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Color Color { get; set; }
    }
}
