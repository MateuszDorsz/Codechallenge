using CodeChallenge.DrawingLogic;
using CodeChallenge.DrawingProperties;
using CodeChallenge.Extensions;
using CodeChallenge.Model.Shape;
using CodeChallenge.ViewModels;
using System;

namespace CodeChallenge.Factory
{
    public class DynamicControlViewModelFactory
    {
        private CircleDrawingLogic circleDrawingLogic = new CircleDrawingLogic();
        private LineDrawingLogic lineDrawingLogic = new LineDrawingLogic();
        private TriangleDrawingLogic triangleDrawingLogic = new TriangleDrawingLogic();

        public DynamicControlViewModel Create(IShape shape)
        {
            switch(shape.Type)
            {
                case ShapeType.Line:
                    var line = (Line)shape;
                    var lineProp = GetLineDrawingProperties(line);
                    return new DynamicControlViewModel(lineDrawingLogic, lineProp);
                case ShapeType.Circle:
                    var circle = (Circle)shape;
                    var circleProperties = GetCircleDrawingProperties(circle);
                    return new DynamicControlViewModel(circleDrawingLogic, circleProperties);
                case ShapeType.Triangle:
                    var triangle = (Triangle)shape;
                    var triangleProperties = GetTriangleDrawingProperties(triangle);
                    return new DynamicControlViewModel(triangleDrawingLogic, triangleProperties);
                default:
                    throw new ArgumentException($"Unknown shape type: {shape.Type}.");
            }
        }

        private LineDrawingProperties GetLineDrawingProperties(Line line)
        {
            var lineProperties = new LineDrawingProperties
            {
                A = new System.Windows.Point(line.A.X, line.A.Y),
                B = new System.Windows.Point(line.B.X, line.B.Y),
                Color = line.Color.ToMediaColor()
            };
            return lineProperties;
        }

        private CircleDrawingProperties GetCircleDrawingProperties(Circle circle)
        {
            var circleProperties = new CircleDrawingProperties
            {
                CenterX = circle.Center.X,
                CenterY = circle.Center.Y,
                Radius = circle.Radius,
                Color = circle.Color.ToMediaColor(),
                Fill = circle.Filled
            };
            return circleProperties;
        }

        private TriangleDrawingProperties GetTriangleDrawingProperties(Triangle triangle)
        {
            var triangleProperties = new TriangleDrawingProperties
            {
                A = new System.Windows.Point(triangle.A.X, triangle.A.Y),
                B = new System.Windows.Point(triangle.B.X, triangle.B.Y),
                C = new System.Windows.Point(triangle.C.X, triangle.C.Y),
                Color = triangle.Color.ToMediaColor(),
                Fill = triangle.Filled
            };
            return triangleProperties;
        }
    }
}
