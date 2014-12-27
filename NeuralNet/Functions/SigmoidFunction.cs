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

        public double ApplyFunction(double d)
        {
            return 1 / 1 + (Math.Exp(d));
        }
    }
}
