using System.IO;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Service.Impl
{
    public class GarminFplService : IGarminFplService
    {
        private readonly IXmlReader<GarminFpl> _xmlReader;

        public GarminFplService(IXmlReader<GarminFpl> xmlReader)
        {
            _xmlReader = xmlReader;
        }

        public GarminFpl GetFromXmlFile(FileInfo file)
        {
            return _xmlReader.ReadToObject(file);
        }
    }
}