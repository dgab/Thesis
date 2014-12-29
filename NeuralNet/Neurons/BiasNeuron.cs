using NeuralNet.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Neurons
{
    public class BiasNeuron : BaseNeuron
    {
        public BiasNeuron(Layer layer)
            :base(layer)
        {
            this.Output = 1;
        }
    }
}
