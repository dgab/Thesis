using NeuralNet.Functions;
using NeuralNet.Neurons;
using NeuralNet.Others;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet.Layers
{
    public abstract class Layer
    {
        public List<BaseNeuron> Neurons { get; protected set; }

        public Layer PreviousLayer { get; set; }

        private TransferFunctions transferFunction;

        public TransferFunctions TransferFunction
        {
            get
            {
                return transferFunction;
            }
            set
            {
                this.transferFunction = value;
                this.Function = FunctionFactory.GetFunction(value);
            }
        }

        public IFunction Function { get; private set; }

        public Layer(Layer previousLayer)
        {
            this.PreviousLayer = previousLayer;
            this.Neurons = new List<BaseNeuron>();

            if (CanAddBiasNeuron())
            {
                this.AddBiasNeuron();
            }
        }

        protected virtual bool CanAddBiasNeuron()
        {
            return true;
        }

        protected virtual bool CanInitializeWeights()
        {
            return true;
        }

        protected virtual void InitWeights()
        {
            foreach (Neuron n in this.Neurons.OfType<Neuron>())
            {
                if (n.CanInitWeight())
                {
                    foreach (BaseNeuron bn in this.PreviousLayer.Neurons)
                    {
                        Synapse s = new Synapse(bn, n);
                        s.InitializeWeight();
                        n.SynapsesIn.Add(s);
                        bn.SynapsesOut.Add(s);
                    }
                }
            }
        }

        public void InitializeWeights()
        {
            if (CanInitializeWeights())
            {
                InitWeights();
            }
        }

        public virtual void CalculateOutputs()
        {
            foreach (BaseNeuron neuron in this.Neurons)
            {
                neuron.CalculateOutput();
            }
        }

        public void UpdateWeights()
        {
            foreach (BaseNeuron neuron in this.Neurons)
            {
                neuron.UpdateWeights();
            }
        }

        #region Neuron adding/removing methods
        public void AddNeuron()
        {
            this.Neurons.Add(new Neuron(this));
        }

        public void AddNeurons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.Neurons.Add(new Neuron(this));
            }
        }

        public void RemoveNeuron(Neuron n)
        {
            this.Neurons.Remove(n);
        }

        protected void AddBiasNeuron()
        {
            this.Neurons.Insert(0, new BiasNeuron(this));
        }

        #endregion

    }
}
