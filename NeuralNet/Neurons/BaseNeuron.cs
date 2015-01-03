using NeuralNet.Layers;

namespace NeuralNet.Neurons
{
    public abstract class BaseNeuron
    {
        public double Output { get; protected set; }

        public double Delta { get; set; }

        protected readonly Layer Layer;

        public double Gradient { get; set; }
        public BaseNeuron(Layer layer)
        {
            this.Layer = layer;
        }

    }
}
