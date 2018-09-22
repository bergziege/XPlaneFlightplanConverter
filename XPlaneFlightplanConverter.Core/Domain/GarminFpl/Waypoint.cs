using System.Xml.Serialization;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl
{
    [XmlRoot(ElementName = "waypoint", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
    public class Waypoint
    {
        [XmlElement(ElementName = "identifier", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Identifier { get; set; }
        [XmlElement(ElementName = "type", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Type { get; set; }
        [XmlElement(ElementName = "country-code", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Countrycode { get; set; }
        [XmlElement(ElementName = "lat", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Lat { get; set; }
        [XmlElement(ElementName = "lon", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Lon { get; set; }
        [XmlElement(ElementName = "comment", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Comment { get; set; }
    }
}