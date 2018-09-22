using System.Collections.Generic;
using System.Globalization;
using System.IO;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence.Impl;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Service.Impl
{
    public class FmsService : IFmsService
    {
        private readonly ITextFileWriter _textFileWriter;

        public FmsService(ITextFileWriter textFileWriter)
        {
            _textFileWriter = textFileWriter;
        }

        public void WriteFmsFlightplanToFile(FmsFlightplan fmsFlightplan, FileInfo fileInfo)
        {
            IList<string> fmsLines = new List<string>();
            fmsLines.Add($"{fmsFlightplan.Header.Source}");
            fmsLines.Add($"{fmsFlightplan.Header.VersionNumber} VERSION");
            fmsLines.Add($"{fmsFlightplan.Header.UnknownPLaceholder}");
            fmsLines.Add($"{fmsFlightplan.Header.WaypointCount}");

            foreach (var fmsFlightplanPlanItem in fmsFlightplan.PlanItems)
                fmsLines.Add(
                    $"{fmsFlightplanPlanItem.Typ} {fmsFlightplanPlanItem.Id} {fmsFlightplanPlanItem.Altitude.ToString(CultureInfo.InvariantCulture)} {fmsFlightplanPlanItem.Latitude.ToString(CultureInfo.InvariantCulture)} {fmsFlightplanPlanItem.Longitude.ToString(CultureInfo.InvariantCulture)}");

            _textFileWriter.WriteAllLines(fileInfo, fmsLines);
        }
    }
}