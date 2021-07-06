using CodeChallenge.Data.File;

namespace CodeChallenge.Data.Factory
{
    public class FileDataReaderFactory : IFileDataReaderFactory
    {
        public IFileDataReader GetReader(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".json":
                    return new JsonFileDataReader();
                default:
                    return new JsonFileDataReader();
            }
        }
    }
}
