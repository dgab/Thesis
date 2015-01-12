using NeuralNet.Functions;
using NeuralNet.Neurons;
using NeuralNet.Others;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace NeuralNet.Layers
{
    [XmlRoot("Layer")]
    [XmlInclude(typeof(InputLayer)),
     XmlInclude(typeof(HiddenLayer)),
     XmlInclude(typeof(OutputLayer))]
    public abstract class Layer
    {
        [XmlArray("Neurons"), XmlArrayItem("Neuron")]
        public List<BaseNeuron> Neurons { get; set; }

        [XmlIgnore]
        public Layer PreviousLayer { get; set; }

        [XmlIgnore]
        private TransferFunctions transferFunction;

        [XmlElement("TransferFunction")]
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

        [XmlIgnore()]
        public IFunction Function { get; private set; }
        /// <summary>
        /// Only for serialization
        /// </summary>
        public Layer()
        {

        }

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


        protected virtual bool CanCalculateGradient()
        {
            return true;
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
            this.Neurons.Add(new BiasNeuron(this));
        }

        #endregion

    }
}
