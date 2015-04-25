using System;

namespace NeuralNet.Functions
{
    /// <summary>
    /// Represents the sigmoid function.
    /// </summary>
    public class SigmoidFunction : IFunction
    {

        /// <summary>
        /// Calculates the output of the sigmoid function in the x point.
        /// </summary>
        /// <param name="x">The x point.</param>
        /// <returns>The return value of the function.</returns>
        public double ApplyFunction(double x)
        {
            //return 2 / (1 + Math.Exp(-2 * x)) - 1;
            return 1 / (1 + Math.Exp(-x));
        }

        /// <summary>
        /// Calculates the derivative of the sigmoid function in the x point.
        /// </summary>
        /// <param name="x">The x point.</param>
        /// <returns>The derivative.</returns>
        public double Derivative(double x)
        {
            double s = ApplyFunction(x);
            return s - (Math.Pow(s, 2));
        }

    }
}
