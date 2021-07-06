using CodeChallenge.Data.File;
using NUnit.Framework;
using System.Linq;

namespace CodeChallenge.Data.Tests.File
{
    [TestFixture]
    public class JsonFileDataReaderTests
    {
        JsonFileDataReader _objectUnderTest;

        [SetUp]
        public void SetUp()
        {
            _objectUnderTest = new JsonFileDataReader();
        }

        [Test]
        public void Should_CreateListOfThreeObjects_When_ReadingInputFileWithThreePrimitives()
        {
            var results = _objectUnderTest.GetShapeProperties("InputFiles/testInput.json").ToList();

            Assert.AreEqual(3, results.Count);
        }
    }
}
