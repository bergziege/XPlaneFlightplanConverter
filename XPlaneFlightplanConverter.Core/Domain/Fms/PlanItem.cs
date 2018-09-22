﻿namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms
{
    public class PlanItem
    {
        public PlanItem(int typ, string id, double altitude, double latitude, double longitude)
        {
            Typ = typ;
            Id = id;
            Altitude = altitude;
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Typ { get; }
        public string Id { get;}
        public double Altitude { get; }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}