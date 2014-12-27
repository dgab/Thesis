using NeuralNet.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Layers
{
    public interface ILayer
    {
        Layer PreviousLayer { get; set; }

        void InitializeWeights();
    }
}
