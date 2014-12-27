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
        /// f(x) = 1.0 / (1.0 + Exp(-x))
        /// </summary>

        public double ApplyFunction(double x)
        {
            //return 2 / (1 + Math.Exp(-2 * x)) - 1;
            return 1 / (1 + Math.Exp(-x));
        }

        /*public double Sigmoid(double x)
        {
            return 2 / (1 + Math.Exp(-2 * x)) - 1;
        }

        public double Derivative(double x)
        {
            double s = Sigmoid(x);
            return 1 - (Math.Pow(s, 2));
        }*/

    }
}
