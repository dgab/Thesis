using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Functions
{
    public class IdentityFunction : IFunction
    {
        public double ApplyFunction(double x)
        {
            return x;
        }

        public double Derivative(double x)
        {
            return 1;
        }
    }
}
