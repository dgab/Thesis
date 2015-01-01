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
        private TransferFunctions transferFunction;
        public TransferFunctions TransferFunction 
        { 
            get
            {
                return transferFunction;
            }
            set
            {
                if (transferFunction != value)
                {
                    transferFunction = value;
                    Function = FunctionFactory.GetFunction(TransferFunction);
                }
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

        public virtual void AddNeuron()
        {
            Neuron n = new Neuron(this);
            this.Neurons.Add(n);
        }

        public virtual void AddNeurons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                AddNeuron();
            }
        }

        public virtual void RemoveNeuron(Neuron n)
        {
            this.Neurons.Remove(n);
        }
    }
}
