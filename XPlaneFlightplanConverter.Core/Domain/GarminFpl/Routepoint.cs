using System.Xml.Serialization;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl
{
    [XmlRoot(ElementName = "route-point", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
    public class Routepoint
    {
        [XmlElement(ElementName = "waypoint-identifier", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Waypointidentifier { get; set; }
        [XmlElement(ElementName = "waypoint-type", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Waypointtype { get; set; }
        [XmlElement(ElementName = "waypoint-country-code", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Waypointcountrycode { get; set; }
    }
}