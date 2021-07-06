namespace CodeChallenge.Data.Factory
{
    public interface IFileDataReaderFactory
    {
        IFileDataReader GetReader(string fileExtension);
    }
}