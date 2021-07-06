using CodeChallenge.Data.Serialization;
using System.Collections.Generic;

namespace CodeChallenge.Model
{
    public interface IShapesCollectionFactory
    {
        ShapesCollection CreateShapesCollection(IEnumerable<ShapeProperties> shapePropertiesCollection);
    }
}