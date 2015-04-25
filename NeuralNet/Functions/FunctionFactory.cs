using System;
using System.Collections.Generic;

namespace NeuralNet.Functions
{
    /// <summary>
    /// The available activation functions.
    /// </summary>
    public enum TransferFunctions
    {
        /// <summary>
        /// Sigmoid activation function.
        /// </summary>
        Sigmoid,

        /// <summary>
        /// Identity activation function.
        /// </summary>
        Identity,

        /// <summary>
        /// Hiperbolic tangent activation function.
        /// </summary>
        Tanh
    }

    /// <summary>
    /// Represent a functionfactory.
    /// </summary>
    public static class FunctionFactory
    {

        private static Dictionary<TransferFunctions, Func<IFunction>> factory = new Dictionary<TransferFunctions, Func<IFunction>>()
        {
            {TransferFunctions.Sigmoid, () => new SigmoidFunction()},
            {TransferFunctions.Identity, () => new IdentityFunction()},
            {TransferFunctions.Tanh, () => new HiperbolicTangentFunction()}
        };

        /// <summary>
        /// Serves the specified activation function.
        /// </summary>
        /// <param name="func">The specified activation function.</param>
        /// <returns>The activation function.</returns>
        public static IFunction GetFunction(TransferFunctions func)
        {
            var function = factory[func];
            return function();
        }
    }
}
