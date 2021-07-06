using CodeChallenge.DrawingProperties;
using System.Windows.Media;

namespace CodeChallenge.DrawingLogic
{
    public class DrawingLogic : IDrawingLogic
    {
        public Geometry Draw(IDrawingProperties properties)
        {
            StreamGeometry geometry = new StreamGeometry();
            return geometry;
        }
    }
}
