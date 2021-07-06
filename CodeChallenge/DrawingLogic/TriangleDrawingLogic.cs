using CodeChallenge.DrawingProperties;
using CodeChallenge.Helpers;
using System.Windows.Media;

namespace CodeChallenge.DrawingLogic
{
    class TriangleDrawingLogic : IDrawingLogic
    {
        private TriangleDrawingProperties _prop;
        private GridScalingHelper _scalingHelper;

        public TriangleDrawingLogic()
        {
            _scalingHelper = GridScalingHelper.GetInstance();
        }

        public Geometry Draw(IDrawingProperties properties)
        {
            _prop = (TriangleDrawingProperties)properties;
            if (properties is TriangleDrawingProperties)
            {
                return TriangleGeometry();
            }
            StreamGeometry geometry = new StreamGeometry();
            return geometry;
        }

        private Geometry TriangleGeometry()
        {
            StreamGeometry geometry = new StreamGeometry();
            using StreamGeometryContext context = geometry.Open();
            Draw(context);
            geometry.Freeze();
            return geometry;
            
        }

        private void Draw(StreamGeometryContext context)
        {
            var scaledA = _scalingHelper.GetScaledPoint(_prop.A.X, _prop.A.Y);
            var scaledB = _scalingHelper.GetScaledPoint(_prop.B.X, _prop.B.Y);
            var scaledC = _scalingHelper.GetScaledPoint(_prop.C.X, _prop.C.Y);

            context.BeginFigure(scaledA, _prop.Fill, true);
            context.LineTo(scaledB, true, true);
            context.LineTo(scaledC, true, true);
        }
    }
}
