using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis.NeuralNet.Layers
{
    public class InputLayer : ILayer
    {
        public List<Neuron> Neurons { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:InputLayer"/> class.
        /// </summary>
        public InputLayer()
        {
            this.Neurons = new List<Neuron>();
        }
    }
}
