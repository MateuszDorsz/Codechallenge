using CodeChallenge.Data.Serialization;
using System.Collections.Generic;

namespace CodeChallenge.Data
{
    public interface IFileDataReader
    {
        IEnumerable<ShapeProperties> GetShapeProperties(string fileName);
    }
}
