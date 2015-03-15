using System;

namespace NeuralNet.Functions
{
    public class HiperbolicTangentFunction : IFunction
    {
        public double ApplyFunction(double x)
        {
            return Math.Tanh(x);
        }

        public double Derivative(double x)
        {
            return (1 - Math.Tanh(x)) * (1 + Math.Tanh(x));
        }
    }
}
