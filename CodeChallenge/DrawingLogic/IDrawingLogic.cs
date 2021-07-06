using CodeChallenge.DrawingProperties;
using System.Windows.Media;

namespace CodeChallenge.DrawingLogic
{
    public interface IDrawingLogic
    {
        Geometry Draw(IDrawingProperties properties);
    }
}