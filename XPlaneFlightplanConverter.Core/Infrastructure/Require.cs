using System;

namespace De.BerndNet2000.XPlaneFlightplanConverter.Core.Infrastructure
{
    public static class Require
    {
        public static T MustNotBeNull<T>(this T objectToTest, string name) where T : class
        {
            if (objectToTest == null)
            {
                throw new ArgumentNullException(name);
            }

            return objectToTest;
        }

        public static string MustNotBeNulllOrWhitespace(this string stringToTest, string name)
        {
            if (string.IsNullOrWhiteSpace(stringToTest))
            {
                throw new ArgumentNullException(name);
            }

            return stringToTest;
        }
    }
}