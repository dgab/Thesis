using System;

namespace NeuralNet.Extensions
{
    /// <summary>
    /// Extension methods for the object.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Another syntax for casting.
        /// </summary>
        /// <typeparam name="T">The type to cast to.</typeparam>
        /// <param name="o">The object which will be casted.</param>
        /// <returns>The casted object.</returns>
        /// <exception cref="InvalidCastException">Occurs on invalid cast.</exception>
        public static T As<T>(this object o)
        {
            return (T)o;
        }
    }
}
