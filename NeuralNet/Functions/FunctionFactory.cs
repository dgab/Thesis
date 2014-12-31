using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Functions
{
    public enum TransferFunctions
    {
        Sigmoid
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
                default:
                    throw new ArgumentOutOfRangeException("Not a valid function!");
            }

            return result;
        }
    }
}
