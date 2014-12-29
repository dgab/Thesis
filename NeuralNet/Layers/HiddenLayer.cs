using NeuralNet.Neurons;
using NeuralNet.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet.Extensions;

namespace NeuralNet.Layers
{
    public class HiddenLayer : Layer, ILayer
    {
        public Layer PreviousLayer { get; set; }

        public HiddenLayer(Layer previousLayer, bool withBias)
            :base(withBias)
        {
            this.PreviousLayer = previousLayer;
        }

        public HiddenLayer(Layer previousLayer)
            : this(previousLayer, true)
        {

        }

        public void InitializeWeights()
        {
            foreach (BaseNeuron n in this.Neurons.OfType<Neuron>())
            {
                n.As<Neuron>().InitializeWeights(PreviousLayer);
            }
        }

        public override void CalculateOutputs()
        {
            foreach (BaseNeuron n in Neurons.OfType<Neuron>())
            {
                n.As<Neuron>().CalculateOutput(PreviousLayer);
            }
        }
    }
}
