using System;
using System.Collections.Generic;

namespace NeuralNet.Functions
{
    public enum TransferFunctions
    {
        Sigmoid,
        Identity,
        Tanh
    }

    public static class FunctionFactory
    {
        private static Dictionary<TransferFunctions, Func<IFunction>> factory = new Dictionary<TransferFunctions, Func<IFunction>>()
        {
            {TransferFunctions.Sigmoid, () => new SigmoidFunction()},
            {TransferFunctions.Identity, () => new IdentityFunction()},
            {TransferFunctions.Tanh, () => new HiperbolicTangentFunction()}
        };

        public static IFunction GetFunction(TransferFunctions func)
        {
            var function = factory[func];
            return function();
        }
    }
}
