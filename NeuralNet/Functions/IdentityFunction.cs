
namespace NeuralNet.Functions
{
    /// <summary>
    /// Represents the identity function.
    /// </summary>
    public class IdentityFunction : IFunction
    {
        /// <summary>
        /// Calculates the output of the identity function in the x point.
        /// </summary>
        /// <param name="x">The x point.</param>
        /// <returns>The return value of the function.</returns>
        public double ApplyFunction(double x)
        {
            return x;
        }

        /// <summary>
        /// Calculates the derivative of the identity function in the x point.
        /// </summary>
        /// <param name="x">The x point.</param>
        /// <returns>The derivative.</returns>
        public double Derivative(double x)
        {
            return 1;
        }
    }
}
