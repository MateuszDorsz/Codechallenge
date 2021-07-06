using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CodeChallenge.Model.Shape
{
    public interface IShape
    {
        ShapeType Type { get; }

        Color Color { get; }

        double MaxDimensionAbsolute { get; }
    }
}
