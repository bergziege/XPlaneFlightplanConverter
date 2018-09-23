using System;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl.Converter.Impl
{
    public class FplToFmsWaypointTypeConverter : IFplToFmsWaypointTypeConverter
    {
        public WaypointType FplWaypointTypeToFms(string fplWaypointType)
        {
            /*
             * 1 - Airport ICAO - AIRPORT
               2 - NDB
               3 - VOR
               11 - Fix - INT
               28 - Lat/Lon Position 
             */

            switch (fplWaypointType)
            {
                case "AIRPORT":
                    return WaypointType.Airport;
                case "NDB":
                    return WaypointType.Ndb;
                case "VOR":
                    return WaypointType.Vor;
                case "INT":
                    return WaypointType.Fix;
                case "USER WAYPOINT":
                    return WaypointType.LatLon;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}