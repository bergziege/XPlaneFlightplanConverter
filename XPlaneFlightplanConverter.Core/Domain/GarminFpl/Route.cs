using System.Collections.Generic;
using System.Xml.Serialization;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl
{
    [XmlRoot(ElementName = "route", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
    public class Route
    {
        [XmlElement(ElementName = "route-name", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Routename { get; set; }
        [XmlElement(ElementName = "flight-plan-index", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Flightplanindex { get; set; }
        [XmlElement(ElementName = "route-point", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public List<Routepoint> Routepoint { get; set; }
    }
}