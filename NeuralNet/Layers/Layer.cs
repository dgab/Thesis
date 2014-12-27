using NeuralNet.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Layers
{
    public abstract class Layer
    {
        public IFunction Function { get; set; }
        public List<Neuron> Neurons { get; set; }

        public Layer()
        {
            this.Neurons = new List<Neuron>();
            this.Function = new SigmoidFunction();
        }

        public virtual void CalculateOutputs()
        {
            foreach (Neuron n in Neurons)
            {
                n.CalculateOutput();
            }
        }
    }
}
