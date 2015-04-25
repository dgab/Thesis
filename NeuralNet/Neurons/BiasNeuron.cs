using NeuralNet.Layers;

namespace NeuralNet.Neurons
{
    /// <summary>
    /// Represents a bias neuron.
    /// </summary>
    public class BiasNeuron : BaseNeuron
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BiasNeuron"/> class.
        /// </summary>
        /// <param name="currentLayer">The layer on which the neuron is created.</param>
        public BiasNeuron(Layer currentLayer)
            : base(currentLayer)
        {
            this.Input = 1;
            this.Output = 1;
        }

        /// <summary>
        /// Determines whether or not the neuron can calulate output.
        /// </summary>
        /// <returns></returns>
        protected override bool CanCalculateOutput()
        {
            return false;
        }
    }
}
