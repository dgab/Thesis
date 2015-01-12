using NeuralNet.Neurons;

namespace NeuralNet.Others
{
    public interface IWeightInitializer
    {
        void InitializeWeights(ref Neuron n);
    }
}
