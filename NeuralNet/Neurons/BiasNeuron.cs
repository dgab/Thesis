using NeuralNet.Layers;

namespace NeuralNet.Neurons
{
    public class BiasNeuron : BaseNeuron
    {
        public BiasNeuron(Layer layer)
            : base(layer)
        {
            this.Output = 1;
        }
    }
}
