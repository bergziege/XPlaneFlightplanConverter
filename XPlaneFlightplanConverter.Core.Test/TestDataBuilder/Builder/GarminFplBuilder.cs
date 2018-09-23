using System.Collections.Generic;
using System.Linq;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl;

namespace XPlaneFlightplanConverter.Core.Test.TestDataBuilder.Builder
{
    public class GarminFplBuilder
    {
        private string _created = "Test";
        private Route _route;
        private Waypointtable _waypointTable;

        public GarminFplBuilder()
        {
            _route = new Route() { Flightplanindex = "1", Routename = "Test", Routepoint = new List<Routepoint>() };
            _waypointTable = new Waypointtable() { Waypoint = new List<Waypoint>() };
        }

        public GarminFpl Build()
        {
            return new GarminFpl() { Created = _created, Route = _route, Waypointtable = _waypointTable };
        }

        public GarminFplBuilder AddWaypoint(string type, string identifier, double lat, double lon)
        {
            Routepoint routepoint = new Routepoint() { Waypointtype = type, Waypointidentifier = identifier, Waypointcountrycode = "DE" };

            Waypoint existingWaypoint = _waypointTable.Waypoint.FirstOrDefault(x =>
                x.Type == type && x.Identifier == identifier && x.Countrycode == "DE");
            if (existingWaypoint == null)
            {
                _waypointTable.Waypoint.Add(new Waypoint() { Type = type, Identifier = identifier, Lat = lat, Lon = lon, Comment = "test", Countrycode = "DE" });
            }

            _route.Routepoint.Add(routepoint);

            return this;
        }
    }
}