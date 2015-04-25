
namespace NeuralNet.Functions
{
    /// <summary>
    /// Represents an activation function.
    /// </summary>
    public interface IFunction
    {
        /// <summary>
        /// Calculates the output of the activation function in the x point.
        /// </summary>
        /// <param name="x">The x point.</param>
        /// <returns>The return value of the function.</returns>
        double ApplyFunction(double x);

        /// <summary>
        /// Calculates the derivative of the sigmoid function in the x point.
        /// </summary>
        /// <param name="x">The x point.</param>
        /// <returns>The derivative.</returns>
        double Derivative(double x);
    }
}
