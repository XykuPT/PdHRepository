using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PdH.Tests
{
    public static class TestUtils
    {
        private static readonly Random RandomGenerator = new Random();

        public static string GetRandomGuidAsString(int? length = null)
        {
            if (length.HasValue)
            {
                var result = Guid.NewGuid().ToString("N");
                while (result.Length < length.Value)
                {
                    result = $"{result}{Guid.NewGuid():N};";
                }
                return result.Substring(0, length.Value);
            }
            return Guid.NewGuid().ToString("N");
        }
        public static string GetRandomNumericString(int min = 0, int max = 999999999)
        {
            return GetRandomNumeric().ToString();
        }
        public static int GetRandomNumeric(int min = 0, int max = 999999999)
        {
            return RandomGenerator.Next(min, max);
        }
    }
}
