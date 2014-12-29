using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Converts an object into a specified type, with different syntax.
        /// </summary>
        /// <typeparam name="T">The type we want to get.</typeparam>
        /// <param name="o">The object we want to cast.</param>
        /// <returns>The casted object</returns>
        /// <exception cref="InvalidCastException"></exception>
        public static T As<T>(this object o)
        {
            return (T)o;
        }
    }
}
