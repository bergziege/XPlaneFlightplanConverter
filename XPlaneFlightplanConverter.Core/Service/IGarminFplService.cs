using System.IO;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Service
{
    public interface IGarminFplService
    {
        GarminFpl GetFromXmlFile(FileInfo file);
    }
}