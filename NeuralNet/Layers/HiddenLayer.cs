using NeuralNet.Extensions;
using NeuralNet.Neurons;
using System.Linq;

namespace NeuralNet.Layers
{
    public class HiddenLayer : Layer, ILayer
    {
        public Layer PreviousLayer { get; set; }

        public HiddenLayer(Layer previousLayer, bool withBias)
            : base(withBias)
        {
            this.PreviousLayer = previousLayer;
        }

        public HiddenLayer(Layer previousLayer)
            : this(previousLayer, true)
        {

        }

        public HiddenLayer(Layer previousLayer, int neurons)
            : base(neurons)
        {
            this.PreviousLayer = previousLayer;
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
