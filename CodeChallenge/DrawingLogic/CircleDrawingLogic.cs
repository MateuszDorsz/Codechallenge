using CodeChallenge.DrawingProperties;
using CodeChallenge.Helpers;
using System.Windows.Media;

namespace CodeChallenge.DrawingLogic
{
    class CircleDrawingLogic : IDrawingLogic
    {
        private CircleDrawingProperties _prop;
        private GridScalingHelper _scalingHelper;

        public CircleDrawingLogic()
        {
            _scalingHelper = GridScalingHelper.GetInstance();
        }
        public Geometry Draw(IDrawingProperties properties)
        {
            _prop = (CircleDrawingProperties)properties;
            if (properties is CircleDrawingProperties)
            {
                return CircleGeometry();
            }
            StreamGeometry geometry = new StreamGeometry();
            return geometry;
        }

        private Geometry CircleGeometry()
        {
            StreamGeometry geometry = new StreamGeometry();
            using StreamGeometryContext context = geometry.Open();
            DrawLine(context);
            geometry.Freeze();
            return geometry;
        }

        private void DrawLine(StreamGeometryContext context)
        {
            var topPoint = _scalingHelper.GetScaledPoint(_prop.CenterX, _prop.CenterY + _prop.Radius);
            var botPoint = _scalingHelper.GetScaledPoint(_prop.CenterX, _prop.CenterY - _prop.Radius);
            var scaledRadius = _scalingHelper.GetScaledDimension(_prop.Radius);
            context.BeginFigure(topPoint, _prop.Fill, true);
            context.ArcTo(botPoint, new System.Windows.Size(scaledRadius, scaledRadius), 180, true, SweepDirection.Clockwise, true, true);
            context.ArcTo(topPoint, new System.Windows.Size(scaledRadius, scaledRadius), 180, true, SweepDirection.Clockwise, true, true);
        }
    }
}
