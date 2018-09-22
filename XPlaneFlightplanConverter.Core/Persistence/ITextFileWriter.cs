using System.Collections.Generic;
using System.IO;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence
{
    public interface ITextFileWriter
    {
        void WriteAllLines(FileInfo file, IEnumerable<string> lines);
    }
}