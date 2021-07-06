using System.Windows.Media;
using System.Windows.Shapes;

namespace CodeChallenge.Controls.Shapes
{
    public class CustomShapeBase : Shape
    {
        public BrushConverter BrushConverter => new BrushConverter();
        public Color Color { get; set; }
        protected override Geometry DefiningGeometry => throw new System.NotImplementedException();
    }
}
