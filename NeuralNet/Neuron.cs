using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis.NeuralNet
{
    public class Neuron
    {
        /// <summary>
        /// Gets or sets the Input.
        /// </summary>
        /// <value>The Input.</value>
        public double Input
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Output.
        /// </summary>
        /// <value>The Output.</value>
        public double Output
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Neuron"/> class.
        /// </summary>
        public Neuron(double input)
        {
            this.Input = input;
        }

        public void CalculateOutput()
        {

        }
    }
}
