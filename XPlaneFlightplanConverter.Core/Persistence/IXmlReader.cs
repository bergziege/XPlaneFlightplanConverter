using System.ComponentModel.Design.Serialization;
using System.IO;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence
{
    public interface IXmlReader<T> : ITextFileReader
    {
        T ReadToObject(FileInfo fileName);
    }
}