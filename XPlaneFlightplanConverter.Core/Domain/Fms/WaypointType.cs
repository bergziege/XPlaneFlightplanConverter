namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms
{
    public enum WaypointType
    {
        Airport = 1,
        Ndb = 2,
        Vor = 3,
        Fix = 11,
        LatLon = 28
    }

    public static class FmsWaypointTypeExtensions
    {
        public static int AsInt(this WaypointType waypointType)
        {
            return (int) waypointType;
        }
    }
}