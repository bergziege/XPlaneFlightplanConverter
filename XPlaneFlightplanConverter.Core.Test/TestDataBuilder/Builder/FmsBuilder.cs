using System.Collections.Generic;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;

namespace XPlaneFlightplanConverter.Core.Test.TestDataBuilder.Builder
{
    public class FmsBuilder
    {
        private Header _header;
        private IList<PlanItem> _planItems = new List<PlanItem>();

        public FmsFlightplan Build()
        {
            _header = new Header(_planItems.Count-1);
            return new FmsFlightplan(_header, _planItems);

        }

        public FmsBuilder AddWaypoint(WaypointType waypointType, string identifier, double alt, double lat, double lon)
        {
            _planItems.Add(new PlanItem(waypointType, identifier, alt, lat, lon));
            return this;
        }
    }
}