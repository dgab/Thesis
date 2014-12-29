using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet;
using NeuralNet.Layers;
using NeuralNet.Neurons;

namespace NeuralNet.Others
{
    public interface IWeightInitializer
    {
        Dictionary<BaseNeuron, double> Initialize(Layer previousLayer);
    }
}
