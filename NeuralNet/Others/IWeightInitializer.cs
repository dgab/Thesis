using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet;
using NeuralNet.Layers;

namespace NeuralNet.Others
{
    public interface IWeightInitializer
    {
        Dictionary<Neuron, double> Initialize(Layer previousLayer, Neuron n);
    }
}
