using CodeChallenge.Model.Coordinates;
using System;

namespace CodeChallenge.Model.Conversion
{
    public class CoordinatesParser : ICoordinatesParser
    {
        public CartesianPoint ToCartesian(string raw)
        {
            var values = raw.Split(';');

            if (values.Length == 2)
            {
                return ParseValues(values);
            }
            else
            {
                throw new ArgumentException($"\"{raw}\" cannot be parsed to cartesian coordinates.");
            }
        }

        private static CartesianPoint ParseValues(string[] values)
        {
            try
            {
                var x = double.Parse(values[0].Trim().Replace(',', '.'), System.Globalization.NumberStyles.Any);
                var y = double.Parse(values[1].Trim().Replace(',', '.'), System.Globalization.NumberStyles.Any);
                return new CartesianPoint(x, y);
            }
            catch (Exception)
            {
                throw new ArgumentException($"\"{values[0]}; {values[1]}\" cannot be parsed to cartesian coordinates.");
            }
        }
    }
}
