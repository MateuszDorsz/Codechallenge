using CodeChallenge.Model.Coordinates;

namespace CodeChallenge.Model.Conversion
{
    public interface ICoordinatesParser
    {
        CartesianPoint ToCartesian(string raw);
    }
}