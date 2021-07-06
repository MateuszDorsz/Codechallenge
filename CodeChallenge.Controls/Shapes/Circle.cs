using System.Windows.Media;

namespace CodeChallenge.Controls.Shapes
{
    public class Circle : CustomShapeBase
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }

        public Circle()
        {
            Stroke = Brushes.Black;
            StrokeThickness = 1;
        }

        protected override Geometry DefiningGeometry 
        { 
            get
            {
                StrokeThickness = 1;
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
            context.BeginFigure(new System.Windows.Point(CenterX + Radius, CenterY), Filled, true);
            context.ArcTo(new System.Windows.Point(CenterX + Radius, CenterY), new System.Windows.Size(Radius, Radius), 180, true, SweepDirection.Clockwise, true, true);
        }
    }
}
