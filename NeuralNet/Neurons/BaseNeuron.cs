using NeuralNet.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Neurons
{
    public abstract class BaseNeuron
    {
        public double Output { get; protected set; }

        protected readonly Layer Layer;

        public BaseNeuron(Layer layer)
        {
            this.Layer = layer;
        }
    }
}
