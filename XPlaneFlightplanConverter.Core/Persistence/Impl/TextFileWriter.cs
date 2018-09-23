using System.Collections.Generic;
using System.IO;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Infrastructure;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Wrapper;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence.Impl
{
    public class TextFileWriter : ITextFileWriter
    {
        private readonly IFileSystem _fileSystem;

        public TextFileWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem.MustNotBeNull(nameof(fileSystem));
        }

        public void WriteAllLines(FileInfo file, IEnumerable<string> lines)
        {
            _fileSystem.WriteAllLines(file, lines);
        }
    }
}