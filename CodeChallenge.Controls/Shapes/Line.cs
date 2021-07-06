using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace CodeChallenge.Controls.Shapes
{
    public class Line : CustomShapeBase
    {
        public Point A { get; set; }
        public Point B { get; set; }

        protected override Geometry DefiningGeometry
        {
            get
            {
                Stroke = new SolidColorBrush(Color);
                StreamGeometry geometry = new StreamGeometry();
                using StreamGeometryContext context = geometry.Open();
                Draw(context);

                return geometry;
            }
        }

        private void Draw(StreamGeometryContext context)
        {
            context.BeginFigure(A, true, true);
            context.LineTo(B, true, true);
        }
    }
}
