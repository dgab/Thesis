using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis.NeuralNet.Layers
{
    public class HiddenLayer : ILayer
    {
        public ILayer PreviousLayer { get; set; }

        public List<Neuron> Neurons { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:HiddenLayer"/> class.
        /// </summary>
        public HiddenLayer(ILayer previousLayer)
        {
            this.PreviousLayer = previousLayer;
        }
    }
}
