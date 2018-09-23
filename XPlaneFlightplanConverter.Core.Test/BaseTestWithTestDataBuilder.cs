using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPlaneFlightplanConverter.Core.Test.TestDataBuilder;

namespace XPlaneFlightplanConverter.Core.Test
{
    [TestClass]
    public class BaseTestWithTestDataBuilder
    {
        public Create Create { get; }

        public BaseTestWithTestDataBuilder()
        {
            Create = new Create();
        }
    }
}