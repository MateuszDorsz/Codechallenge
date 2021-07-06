using CodeChallenge.Data.Serialization;
using CodeChallenge.Model.Conversion;
using CodeChallenge.Model.Shape;
using System.Collections.Generic;

namespace CodeChallenge.Model
{
    public class ShapesCollectionFactory : IShapesCollectionFactory
    {
        private readonly IColorParser _colorParser;
        private readonly ICoordinatesParser _coordinatesParser;

        public ShapesCollectionFactory(IColorParser colorParser, ICoordinatesParser coordinatesParser)
        {
            _colorParser = colorParser;
            _coordinatesParser = coordinatesParser;
        }

        public ShapesCollection CreateShapesCollection(IEnumerable<ShapeProperties> shapePropertiesCollection)
        {
            var collection = new ShapesCollection();

            foreach (var shapeProperties in shapePropertiesCollection)
            {
                switch (shapeProperties.Type.ToLower())
                {
                    case "line":
                        var line = new Line(
                            _coordinatesParser.ToCartesian(shapeProperties.A),
                            _coordinatesParser.ToCartesian(shapeProperties.B),
                            _colorParser.Parse(shapeProperties.Color)
                            );
                        collection.Add(line);
                        break;
                    case "circle":
                        var circle = new Circle(
                            _coordinatesParser.ToCartesian(shapeProperties.Center),
                            (double)shapeProperties.Radius,
                            _colorParser.Parse(shapeProperties.Color),
                            (bool)shapeProperties.Filled
                            );
                        collection.Add(circle);
                        break;
                    case "triangle":
                        var triangle = new Triangle(
                            _coordinatesParser.ToCartesian(shapeProperties.A),
                            _coordinatesParser.ToCartesian(shapeProperties.B),
                            _coordinatesParser.ToCartesian(shapeProperties.C),
                            _colorParser.Parse(shapeProperties.Color),
                            (bool)shapeProperties.Filled
                            );
                        collection.Add(triangle);
                        break;
                }
            }

            return collection;
        }
    }
}
