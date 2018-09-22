using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl.Converter
{
    public interface IFplToFmsWaypointTypeConverter
    {
        WaypointType FplWaypointTypeToFms(string fplWaypointType);
    }
}