using System;
using System.Drawing;

namespace CodeChallenge.Model.Conversion
{
    public class ColorParser : IColorParser
    {
        public Color Parse(string raw)
        {
            try
            {
                var values = raw.Split(';');
                if (values.Length == 4)
                {
                    return Color.FromArgb(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
                }
                throw new ArgumentException($"\"{raw}\" cannot be parsed to color.");
            }
            catch
            {
                throw new ArgumentException($"\"{raw}\" cannot be parsed to ccolor.");
            }
        }
    }
}
