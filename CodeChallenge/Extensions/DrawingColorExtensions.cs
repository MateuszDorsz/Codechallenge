using MediaColor = System.Windows.Media.Color;
using DrawingColor = System.Drawing.Color;

namespace CodeChallenge.Extensions
{
    public static class DrawingColorExtensions
    {
        public static MediaColor ToMediaColor(this DrawingColor color)
        {
            return MediaColor.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
