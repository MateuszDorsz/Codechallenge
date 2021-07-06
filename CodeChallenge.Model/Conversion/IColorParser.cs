using System.Drawing;

namespace CodeChallenge.Model.Conversion
{
    public interface IColorParser
    {
        Color Parse(string raw);
    }
}