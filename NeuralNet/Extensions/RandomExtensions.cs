using System;

namespace NeuralNet.Extensions
{
    public static class RandomExtensions
    {
        private static Random defaultRandom;

        public static Random Default
        {
            get
            {
                if (defaultRandom == null)
                {
                    defaultRandom = new Random();
                }
                return RandomExtensions.defaultRandom;
            }
        }

        public static double NextDouble(this Random r, double min, double max)
        {
            return r.NextDouble() * (max - min) + min;
        }
    }
}
