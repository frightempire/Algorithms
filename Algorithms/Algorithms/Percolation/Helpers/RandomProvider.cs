using System;

namespace Algorithms.Percolation.Helpers
{
    public class RandomProvider
    {
        private readonly Random _random = new Random();

        public int GetRandomNumberInRange(int lower, int upper)
        {
            return _random.Next(lower, upper + 1);
        }
    }
}