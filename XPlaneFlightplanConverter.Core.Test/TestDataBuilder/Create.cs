using XPlaneFlightplanConverter.Core.Test.TestDataBuilder.Builder;

namespace XPlaneFlightplanConverter.Core.Test.TestDataBuilder
{
    public class Create
    {
        public GarminFplBuilder GarminFpl()
        {
            return new GarminFplBuilder();
        }

        public FmsBuilder FmsFlightplan()
        {
            return new FmsBuilder();
        }
    }
}