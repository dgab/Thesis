using System;

namespace NeuralNet.Extensions
{
    /// <summary>
    /// Extension methods for the random class
    /// </summary>
    public static class RandomExtensions
    {
        private static Random defaultRandom;

        /// <summary>
        /// A singleton instance.
        /// </summary>
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

        /// <summary>
        /// Returns a random double between in the specified range.
        /// </summary>
        /// <param name="r">Random</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>A random double value.</returns>
        public static double NextDouble(this Random r, double min, double max)
        {
            return r.NextDouble() * (max - min) + min;
        }
    }
}
