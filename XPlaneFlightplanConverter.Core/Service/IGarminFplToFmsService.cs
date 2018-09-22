using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Service
{
    public interface IGarminFplToFmsService
    {
        FmsFlightplan CreateFmsFlightplanFromGarminFpl(GarminFpl garminFlightplan);
    }
}