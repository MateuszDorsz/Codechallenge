using CodeChallenge.Data.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeChallenge.Data.File
{
    public class JsonFileDataReader : IFileDataReader
    {
        public IEnumerable<ShapeProperties> GetShapeProperties(string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();
            using FileStream s = System.IO.File.Open(fileName, FileMode.Open);
            using StreamReader sr = new StreamReader(s);
            using JsonReader reader = new JsonTextReader(sr);
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    yield return serializer.Deserialize<ShapeProperties>(reader);
                }
            }

        }
    }
}
