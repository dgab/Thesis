using System;

namespace NeuralNet.Functions
{
    public enum TransferFunctions
    {
        Sigmoid,
        Identity,
        Step
    }
    public static class FunctionFactory
    {
        public static IFunction GetFunction(TransferFunctions func)
        {
            IFunction result;

            switch (func)
            {
                case TransferFunctions.Sigmoid:
                    result = new SigmoidFunction();
                    break;
                case TransferFunctions.Identity:
                    result = new IdentityFunction();
                    break;
                case TransferFunctions.Step:
                    result = new StepFunction();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Not a valid function!");
            }

            return result;
        }
    }
}
