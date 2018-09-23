using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl.Converter.Impl;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Service;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Service.Impl;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XPlaneFlightplanConverter.Core.Test.Service
{
    [TestClass]
    public class GarminFplToFmsServiceTest : BaseTestWithTestDataBuilder
    {
        [TestMethod]
        [TestCategory("unit")]
        public void Converting_FPL_should_give_correct_FMS()
        {
            var garminFplBuilder = Create.GarminFpl();
            garminFplBuilder.AddWaypoint("AIRPORT", "EDDC", 51.134344, 51.134344);
            garminFplBuilder.AddWaypoint("VOR", "DRN", 51.015547, 13.598889);
            garminFplBuilder.AddWaypoint("INT", "DC422", 51.065489, 13.457303);
            garminFplBuilder.AddWaypoint("NDB", "FS", 51.193011, 13.850031);
            garminFplBuilder.AddWaypoint("USER WAYPOINT", "TEST1", 51.378353, 13.115295);
            garminFplBuilder.AddWaypoint("USER WAYPOINT", "TEST2", -51.378353, 13.115295);
            garminFplBuilder.AddWaypoint("USER WAYPOINT", "TEST3", -51.378353, -13.115295);
            garminFplBuilder.AddWaypoint("USER WAYPOINT", "TEST4", 51.378353, -13.115295);
            GarminFpl garminFpl = garminFplBuilder.Build();

            IGarminFplToFmsService service = new GarminFplToFmsService(new FplToFmsWaypointTypeConverter());
            FmsFlightplan fms = service.CreateFmsFlightplanFromGarminFpl(garminFpl);

            fms.Header.Source.Should().Be('I');
            fms.Header.VersionNumber.Should().Be(3);
            fms.Header.WaypointCount.Should().Be(7);

            PlanItem waypoint1 = fms.PlanItems[0];
            waypoint1.Typ.Should().Be(WaypointType.Airport);
            waypoint1.Id.Should().Be("EDDC");
            waypoint1.Altitude.Should().Be(0);
            waypoint1.Latitude.Should().Be(51.134344);
            waypoint1.Longitude.Should().Be(51.134344);

            PlanItem waypoint5 = fms.PlanItems[4];
            waypoint5.Typ.Should().Be(WaypointType.LatLon);
            waypoint5.Id.Should().Be("+51.378_+013.115");

            PlanItem waypoint6 = fms.PlanItems[5];
            waypoint6.Typ.Should().Be(WaypointType.LatLon);
            waypoint6.Id.Should().Be("-51.378_+013.115");

            PlanItem waypoint7 = fms.PlanItems[6];
            waypoint7.Typ.Should().Be(WaypointType.LatLon);
            waypoint7.Id.Should().Be("-51.378_-013.115");

            PlanItem waypoint8 = fms.PlanItems[7];
            waypoint8.Typ.Should().Be(WaypointType.LatLon);
            waypoint8.Id.Should().Be("+51.378_-013.115");
        }
    }
}
