/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */

using System.Xml.Serialization;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl
{
    [XmlRoot(ElementName = "flight-plan", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
    public class GarminFpl
    {
        [XmlElement(ElementName = "created", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public string Created { get; set; }
        [XmlElement(ElementName = "waypoint-table", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public Waypointtable Waypointtable { get; set; }
        [XmlElement(ElementName = "route", Namespace = "http://www8.garmin.com/xmlschemas/FlightPlan/v1")]
        public Route Route { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }

}
