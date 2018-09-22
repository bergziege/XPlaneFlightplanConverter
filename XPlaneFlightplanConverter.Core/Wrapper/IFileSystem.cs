using System.Collections.Generic;
using System.IO;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Wrapper
{
    public interface IFileSystem
    {
        string ReadAllText(FileInfo file);
        void WriteAllLines(FileInfo file, IEnumerable<string> lines);
    }
}