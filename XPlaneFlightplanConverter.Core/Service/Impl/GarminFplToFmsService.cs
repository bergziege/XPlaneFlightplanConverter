using System;
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
                Waypoint waypointToRoutepoint = garminFlightplan.Waypointtable.Waypoint.Single(x =>
                    x.Identifier == routepoint.Waypointidentifier && x.Type == routepoint.Waypointtype &&
                    x.Countrycode == routepoint.Waypointcountrycode);
                double lat = double.Parse(waypointToRoutepoint.Lat, CultureInfo.InvariantCulture);
                double lon = double.Parse(waypointToRoutepoint.Lon, CultureInfo.InvariantCulture);
                WaypointType waypointType = _fplToFmsWaypointTypeConverter.FplWaypointTypeToFms(waypointToRoutepoint.Type);
                string id;
                if (waypointType == WaypointType.LatLon)
                {
                    id = CreateIdentifierFromCoordinates(lat, lon);
                }
                else
                {
                    id = waypointToRoutepoint.Identifier;
                }
                planItems.Add(new PlanItem(
                    waypointType.AsInt(),
                    id,
                    0,
                    lat,
                    lon)
                );
            }

            Header header = new Header(planItems.Count - 1);
            return new FmsFlightplan(header, planItems);
        }

        private string CreateIdentifierFromCoordinates(double lat, double lon)
        {
            string latPrefix = lat < 0 ? "-": "+";
            string lonPrefix = lon < 0 ? "-": "+";
            string latPart = lat.ToString("00.000", CultureInfo.InvariantCulture);
            string lonPart = lon.ToString("000.000", CultureInfo.InvariantCulture);

            return $"{latPrefix}{latPart}_{lonPrefix}{lonPart}";
        }
    }
}