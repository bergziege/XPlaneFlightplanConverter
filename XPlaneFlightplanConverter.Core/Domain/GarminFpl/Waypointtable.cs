using System.Collections.Generic;
using System.Xml.Serialization;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl
{
    [XmlRoot(ElementName = "waypoint-table", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
    public class Waypointtable
    {
        [XmlElement(ElementName = "waypoint", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public List<Waypoint> Waypoint { get; set; }
    }
}