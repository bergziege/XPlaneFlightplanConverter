using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Service;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Service.Impl;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using XPlaneFlightplanConverter.Core.Test.TestDataBuilder.Builder;

namespace XPlaneFlightplanConverter.Core.Test.Service
{
    [TestClass]
    public class FmsServiceTest : BaseTestWithTestDataBuilder
    {
        [TestMethod]
        public void Test_Convert_model_to_lines()
        {
            FmsBuilder fmsFlightplan = Create.FmsFlightplan();
            fmsFlightplan.AddWaypoint(WaypointType.Airport, "EDDC", 0, 51.134344, 13.768);
            fmsFlightplan.AddWaypoint(WaypointType.LatLon, "+51.378_+013.115",0, 51.378353, 13.115295);
            FmsFlightplan flightplan = fmsFlightplan.Build();

            FileInfo outputFile = new FileInfo("out.fms");
            IList<string> lines = null;
            Mock<ITextFileWriter> textWriterMock = new Mock<ITextFileWriter>();
            textWriterMock.Setup(x => x.WriteAllLines(outputFile, It.IsAny<IEnumerable<string>>())).Callback<FileInfo, IEnumerable<string>>((f,s)=>lines = s.ToList());

            IFmsService service = new FmsService(textWriterMock.Object);
            service.WriteFmsFlightplanToFile(flightplan, outputFile);

            lines.Count.Should().Be(6);
            lines[0].Should().Be("I");
            lines[1].Should().Be("3 VERSION");
            lines[2].Should().Be("1");
            lines[3].Should().Be("1");
            lines[4].Should().Be("1 EDDC 0 51.134344 13.768");
            lines[5].Should().Be("28 +51.378_+013.115 0 51.378353 13.115295");
        }

        [TestMethod]
        public void Create_intance_with_null_should_throw_exception()
        {
            Action createInstanceWithNullParameter = ()=> new FmsService(null);
            createInstanceWithNullParameter.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null.\nParameter name: textFileWriter");
        }
    }
}