using System.Windows.Media;

namespace CodeChallenge.DrawingProperties
{
    class CircleDrawingProperties : IDrawingProperties, IFillable
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Radius { get; set; }
        public bool Fill { get; set; }
        public Color Color { get; set; }
    }
}
