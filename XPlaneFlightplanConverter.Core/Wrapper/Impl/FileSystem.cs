using System.Collections.Generic;
using System.IO;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Wrapper.Impl
{
    public class FileSystem : IFileSystem
    {
        public string ReadAllText(FileInfo file)
        {
            return File.ReadAllText(file.FullName);
        }

        public void WriteAllLines(FileInfo file, IEnumerable<string> lines)
        {
            File.WriteAllLines(file.FullName, lines);
        }
    }
}