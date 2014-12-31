using NeuralNet.Functions;
using NeuralNet.Neurons;
using NeuralNet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Layers
{
    public abstract class Layer
    {
        public TransferFunctions TransferFunction 
        { 
            get;
            set
            {
                TransferFunction = value;
                Function = FunctionFactory.GetFunction(TransferFunction);
            }
        }

        public IFunction Function
        {
            get;
            set;
        }

        public List<BaseNeuron> Neurons { get; set; }

        public Layer(bool withBias)
        {
            this.Neurons = new List<BaseNeuron>();
            this.TransferFunction = TransferFunctions.Sigmoid;

            if (withBias)
            {
                Neurons.Add(new BiasNeuron(this));
            }
        }

        public Layer()
            :this(true)
        {

        }

        public virtual void CalculateOutputs()
        {
            foreach (BaseNeuron n in Neurons.OfType<Neuron>())
            {
                n.As<Neuron>().CalculateOutput();
            }
        }
    }
}
