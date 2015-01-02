using NeuralNet.Layers;
using NeuralNet.Neurons;
using System.Collections.Generic;

namespace NeuralNet.Others
{
    public interface IWeightInitializer
    {
        Dictionary<BaseNeuron, double> Initialize(Layer previousLayer);
    }
}
