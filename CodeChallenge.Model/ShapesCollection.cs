using CodeChallenge.Model.Shape;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Model
{
    public class ShapesCollection
    {
        public ShapesCollection()
        {
            Shapes = new List<IShape>();
        }

        public IList<IShape> Shapes { get; private set; }

        public void Add(IShape shape)
        {
            Shapes.Add(shape);
        }

        public double MaxDimensionAbsolute => Shapes.Max(x => x.MaxDimensionAbsolute);
    }
}
