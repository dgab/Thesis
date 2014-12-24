using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thesis.NeuralNet.Layers
{
    public interface ILayer
    {
        List<Neuron> Neurons { get; set; }
    }
}
