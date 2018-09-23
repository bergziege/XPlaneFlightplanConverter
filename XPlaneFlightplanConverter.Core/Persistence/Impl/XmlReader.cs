using System.IO;
using System.Xml.Serialization;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Infrastructure;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Wrapper;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence.Impl
{
    public class XmlReader<T> : TextFileReader, IXmlReader<T> where T : class
    {
        public XmlReader(IFileSystem fileSystem) : base(fileSystem)
        {
            fileSystem.MustNotBeNull(nameof(fileSystem));
        }


        public T ReadToObject(FileInfo fileName)
        {
            string xmlRaw = ReadAllText(fileName);

            var serializer = new XmlSerializer(typeof(T));
            T objectFromXml;
            using (var stringReader = new StringReader(xmlRaw))
            {
                objectFromXml= (T)serializer.Deserialize(stringReader);
            }

            return objectFromXml;
        }
    }
}