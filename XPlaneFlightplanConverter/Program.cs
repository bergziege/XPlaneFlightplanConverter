using System.IO;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.Fms;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl.Converter;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Domain.GarminFpl.Converter.Impl;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Persistence.Impl;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Service;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Service.Impl;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Wrapper;
using De.BerndNet2000.XPlaneFlightplanConverter.Core.Wrapper.Impl;
using Unity;
using Unity.Lifetime;

namespace De.BerndNet2000.XPlaneFlightplanConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IUnityContainer container = CreateContainer();
            
            IGarminFplService garminFplService = container.Resolve<IGarminFplService>();
            GarminFpl garminFlightplan = garminFplService.GetFromXmlFile(new FileInfo(args[0]));

            IGarminFplToFmsService garminToFmsService = container.Resolve<IGarminFplToFmsService>();
            FmsFlightplan fmsFlightplan = garminToFmsService.CreateFmsFlightplanFromGarminFpl(garminFlightplan);

            IFmsService fmsService = container.Resolve<IFmsService>();
            fmsService.WriteFmsFlightplanToFile(fmsFlightplan,new FileInfo(args[1]));
        }

        private static IUnityContainer CreateContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IFileSystem, FileSystem>(new ContainerControlledLifetimeManager());
            container.RegisterType<IXmlReader<GarminFpl>, XmlReader<GarminFpl>>();
            container.RegisterType<IGarminFplService, GarminFplService>();
            container.RegisterType<IFplToFmsWaypointTypeConverter, FplToFmsWaypointTypeConverter>();
            container.RegisterType<IGarminFplToFmsService, GarminFplToFmsService>();
            container.RegisterType<ITextFileWriter, TextFileWriter>();
            container.RegisterType<IFmsService, FmsService>();
            return container;
        }
    }
}