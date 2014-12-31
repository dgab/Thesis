using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Functions
{

    public class SigmoidFunction : IFunction
    {

        /// <summary>
        /// Sigmoid function: f(x) = 1.0 / (1.0 + Exp(-x))
        /// </summary>
        public double ApplyFunction(double x)
        {
            //return 2 / (1 + Math.Exp(-2 * x)) - 1;
            return 1 / (1 + Math.Exp(-x));
        }

        /// <summary>
        /// Derivative of the sigmoid function: f'(x) = f(x) * (1 - f(x))
        /// </summary>
        /// <param name="x">The x</param>
        /// <returns>The value of the derivative in the point x.</returns>
        public double Derivative(double x)
        {
            double s = ApplyFunction(x);
            return s - (Math.Pow(s, 2));
        }

    }
}
