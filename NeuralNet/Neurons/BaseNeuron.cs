using NeuralNet.Layers;

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
