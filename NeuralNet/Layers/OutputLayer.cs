using NeuralNet.Neurons;
using NeuralNet.Others;
using NeuralNet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Layers
{
    public class OutputLayer : Layer, ILayer
    {
        public Layer PreviousLayer { get; set; }

        public OutputLayer(Layer previousLayer, bool withBias)
            :base(withBias)
        {
            this.PreviousLayer = previousLayer;
        }

        public OutputLayer(Layer previousLayer)
            :this(previousLayer, true)
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
