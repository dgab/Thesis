using NeuralNet.Extensions;
using NeuralNet.Neurons;
using System.Linq;

namespace NeuralNet.Layers
{
    public class OutputLayer : Layer, ILayer
    {
        public Layer PreviousLayer { get; set; }

        public OutputLayer(Layer previousLayer, bool withBias)
            : base(withBias)
        {
            this.PreviousLayer = previousLayer;
        }

        public OutputLayer(Layer previousLayer)
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
