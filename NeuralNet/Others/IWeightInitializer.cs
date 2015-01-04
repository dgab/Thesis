using NeuralNet.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Others
{
    public interface IWeightInitializer
    {
        void InitializeWeights(ref Neuron n);
    }
}
