using NeuralNet.Neurons;

namespace NeuralNet.Others
{
    /// <summary>
    /// Represents a weight initializer.
    /// </summary>
    public interface IWeightInitializer
    {
        /// <summary>
        /// Capable of initializing weights on the given neuron.
        /// </summary>
        /// <param name="n">The given neuron.</param>
        void InitializeWeights(ref Neuron n);
    }
}
