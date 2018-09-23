using System.Collections.Generic;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Infrastructure;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms
{
    public class FmsFlightplan
    {
        public FmsFlightplan(Header header, IList<PlanItem> planItems)
        {
            Header = header.MustNotBeNull(nameof(header));
            PlanItems = planItems.MustNotBeNull(nameof(planItems));
        }

        public Header Header { get; }
        public IList<PlanItem> PlanItems { get; }
    }
}