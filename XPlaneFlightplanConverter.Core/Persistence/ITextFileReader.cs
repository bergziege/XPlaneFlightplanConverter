using System.IO;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence
{
    public interface ITextFileReader
    {
        string ReadAllText(FileInfo textFile);
    }
}