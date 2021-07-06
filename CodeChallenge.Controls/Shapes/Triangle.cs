using System.Windows;
using System.Windows.Media;

namespace CodeChallenge.Controls.Shapes
{
    public class Triangle : CustomShapeBase
    {
        public bool Filled { get; set; }
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        protected override Geometry DefiningGeometry
        {
            get
            {
                StreamGeometry geometry = new StreamGeometry();
                using StreamGeometryContext context = geometry.Open();
                Draw(context);

                if (Filled)
                {
                    Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(Color);
                }

                return geometry;
            }
        }

        private void Draw(StreamGeometryContext context)
        {
            context.BeginFigure(A, Filled, true);
            context.LineTo(B, true, true);
            context.LineTo(C, true, true);
        }
    }
}
