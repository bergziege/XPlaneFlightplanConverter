namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms
{
    public class Header
    {
        public Header(int waypointCount)
        {
            WaypointCount = waypointCount;
        }

        public char Source { get; } = 'I';
        public int VersionNumber { get; } = 3;
        public int UnknownPLaceholder { get; } = 1;
        public int WaypointCount { get; }
    }
}