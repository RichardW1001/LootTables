using System;

namespace Loot
{
    public class RandomGenerator : IRandomGenerator
    {
        private static readonly Random Random = new Random();

        public double NextDouble()
        {
            return Random.NextDouble();
        }
    }
}