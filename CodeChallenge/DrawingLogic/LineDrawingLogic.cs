using CodeChallenge.DrawingProperties;
using CodeChallenge.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Ink;
using System.Windows.Media;

namespace CodeChallenge.DrawingLogic
{
    class LineDrawingLogic : IDrawingLogic
    {
        private LineDrawingProperties _prop;
        private GridScalingHelper _scalingHelper;

        public LineDrawingLogic()
        {
            _scalingHelper = GridScalingHelper.GetInstance();
        }

        public Geometry Draw(IDrawingProperties properties)
        {
            _prop = (LineDrawingProperties)properties;
            if(properties is LineDrawingProperties)
            {
                return LineGeometry();
            }
            StreamGeometry geometry = new StreamGeometry();
            return geometry;
        }

        private Geometry LineGeometry()
        {
            StreamGeometry geometry = new StreamGeometry();
            using StreamGeometryContext context = geometry.Open();
            DrawLine(context);
            geometry.Freeze();
            return geometry;
            
        }

        private void DrawLine(StreamGeometryContext context)
        {
            var scaledA = _scalingHelper.GetScaledPoint(_prop.A.X, _prop.A.Y);
            var scaledB = _scalingHelper.GetScaledPoint(_prop.B.X, _prop.B.Y);

            context.BeginFigure(scaledA, true, true);
            context.LineTo(scaledB, true, true);
            context.Close();
        }
    }
}
