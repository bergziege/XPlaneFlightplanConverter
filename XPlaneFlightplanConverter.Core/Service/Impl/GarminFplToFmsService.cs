using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl.Converter;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl.Converter.Impl;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Service.Impl
{
    public class GarminFplToFmsService : IGarminFplToFmsService
    {
        private readonly IFplToFmsWaypointTypeConverter _fplToFmsWaypointTypeConverter;

        public GarminFplToFmsService(IFplToFmsWaypointTypeConverter fplToFmsWaypointTypeConverter)
        {
            _fplToFmsWaypointTypeConverter = fplToFmsWaypointTypeConverter;
        }

        public FmsFlightplan CreateFmsFlightplanFromGarminFpl(GarminFpl garminFlightplan)
        {
            List<PlanItem> planItems = new List<PlanItem>();

            foreach (var routepoint in garminFlightplan.Route.Routepoint)
            {
                var waypointToRoutepoint = garminFlightplan.Waypointtable.Waypoint.Single(x =>
                    x.Identifier == routepoint.Waypointidentifier && x.Type == routepoint.Waypointtype &&
                    x.Countrycode == routepoint.Waypointcountrycode);
                var lat = double.Parse(waypointToRoutepoint.Lat, CultureInfo.InvariantCulture);
                var lon = double.Parse(waypointToRoutepoint.Lon, CultureInfo.InvariantCulture);
                planItems.Add(new PlanItem(
                    _fplToFmsWaypointTypeConverter.FplWaypointTypeToFms(waypointToRoutepoint.Type).AsInt(),
                    waypointToRoutepoint.Identifier,
                    0,
                    lat,
                    lon)
                );
            }

            Header header = new Header(planItems.Count - 1);
            return new FmsFlightplan(header, planItems);
        }
    }
}