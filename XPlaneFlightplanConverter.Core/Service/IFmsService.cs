using System.IO;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Service
{
    public interface IFmsService
    {
        void WriteFmsFlightplanToFile(FmsFlightplan fmsFlightplan, FileInfo fileInfo);
    }
}