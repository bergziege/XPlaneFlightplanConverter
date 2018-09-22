using System.Collections.Generic;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms
{
    public class FmsFlightplan
    {
        public FmsFlightplan(Header header, IList<PlanItem> planItems)
        {
            Header = header;
            PlanItems = planItems;
        }

        public Header Header { get; }
        public IList<PlanItem> PlanItems { get; }
    }
}