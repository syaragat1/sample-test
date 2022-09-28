using System;

namespace Common
{
    public static class RandomNumberGenerator
    {
        private static Random _random = new Random();
        public static int Next => _random.Next(5, 25);
    }
}
