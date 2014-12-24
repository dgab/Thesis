using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis.NeuralNet.Layers
{
    public class OutputLayer : ILayer
    {
        public ILayer PreviousLayer { get; set; }
        public List<Neuron> Neurons { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OutputLayer"/> class.
        /// </summary>
        public OutputLayer(ILayer previousLayer)
        {
            this.PreviousLayer = previousLayer;
        }
    }
}
