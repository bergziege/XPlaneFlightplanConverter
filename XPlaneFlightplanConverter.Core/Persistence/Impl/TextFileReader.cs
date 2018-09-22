using System.IO;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Wrapper;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence.Impl
{
    public class TextFileReader : ITextFileReader
    {
        private readonly IFileSystem _fileSystem;

        public TextFileReader(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string ReadAllText(FileInfo textFile)
        {
            return _fileSystem.ReadAllText(textFile);
        }
    }
}