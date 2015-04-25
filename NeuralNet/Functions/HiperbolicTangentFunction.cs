using System;

namespace NeuralNet.Functions
{
    /// <summary>
    /// Represents the hiperbolic tangent function.
    /// </summary>
    public class HiperbolicTangentFunction : IFunction
    {
        /// <summary>
        /// Calculates the output of the hiperbolic tangent function in the x point.
        /// </summary>
        /// <param name="x">The x point.</param>
        /// <returns>The return value of the function.</returns>
        public double ApplyFunction(double x)
        {
            return Math.Tanh(x);
        }

        /// <summary>
        /// Calculates the derivative of the hiperbolic tangent function in the x point.
        /// </summary>
        /// <param name="x">The x point.</param>
        /// <returns>The derivative.</returns>
        public double Derivative(double x)
        {
            return (1 - Math.Tanh(x)) * (1 + Math.Tanh(x));
        }
    }
}
