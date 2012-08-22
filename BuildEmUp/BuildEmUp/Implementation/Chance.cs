using System;

namespace BuildEmUp.Implementation
{
    public class Chance : IRandom
    {
        private readonly Random _random;

        public Chance()
        {
            _random = new Random(DateTime.Now.Millisecond);
        }

        public int Next(int minValue, int maxValueExcluded)
        {
            return _random.Next(minValue, maxValueExcluded);
        }

        public decimal NextDecimal(int minValue, int maxValueExcluded)
        {
            return _random.Next(minValue, maxValueExcluded);
        }
    }
}