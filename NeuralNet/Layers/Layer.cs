using NeuralNet.Functions;
using NeuralNet.Neurons;
using NeuralNet.Others;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NeuralNet.Layers
{
    [XmlRoot("Layer")]
    [XmlInclude(typeof(InputLayer)),
    XmlInclude(typeof(HiddenLayer)),
    XmlInclude(typeof(OutputLayer))]
    public abstract class Layer
    {

        private TransferFunctions transferFunction;

        [XmlAttribute("function")]
        public TransferFunctions TransferFunction
        {
            get
            {
                return transferFunction;
            }
            set
            {
                this.transferFunction = value;
                this.Function = FunctionFactory.GetFunction(this.TransferFunction);
            }
        }

        [XmlIgnore()]
        public IFunction Function { get; set; }

        [XmlArray("Neurons")]
        [XmlArrayItem("Neuron")]
        public List<Neuron> Neurons { get; set; }

        [XmlIgnore()]
        public Layer PreviousLayer { get; set; }

        public readonly IWeightInitializer WeightInitializer = new RandomInitializer();
        public Layer()
        {
            this.TransferFunction = TransferFunctions.Sigmoid;
            this.Neurons = new List<Neuron>();
            this.AddBiasNeuron();
        }

        public Layer(IWeightInitializer weightInitializer)
            : this()
        {
            if (weightInitializer != null)
            {
                this.WeightInitializer = weightInitializer;
            }
        }
        #region NeuronList modifying methods.

        public void AddNeuron()
        {
            this.Neurons.Add(new Neuron(this));
        }

        protected virtual bool CanAddBiasNeuron()
        {
            return true;
        }

        protected void AddBiasNeuron()
        {
            if (CanAddBiasNeuron())
            {
                this.Neurons.Add(new BiasNeuron(this));
            }
        }

        public void AddNeurons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                AddNeuron();
            }
        }

        public void RemoveNeuron(Neuron n)
        {
            this.Neurons.Remove(n);
        }
        #endregion

        #region FeedForward
        protected virtual bool CanInitializeWeights()
        {
            return !(this.GetType() == typeof(InputLayer));
        }

        public void InitializeWeights()
        {
            if (CanInitializeWeights())
            {
                for (int i = 0; i < this.Neurons.Count; i++)
                {
                    Neuron n = this.Neurons[i];
                    if (!(n is BiasNeuron))
                    {
                        WeightInitializer.InitializeWeights(ref n);
                    }
                }
            }
        }


        public virtual void CalculateOutputs()
        {
            foreach (Neuron n in this.Neurons)
            {
                n.CalculateOutput();
            }
        }
        #endregion

        #region Backprop

        public void UpdateWeights()
        {
            if (!(this is InputLayer))
            {
                foreach (Neuron n in this.Neurons)
                {
                    foreach (Synapse s in n.Weights)
                    {
                        s.Update();
                    }
                }
            }
        }
        #endregion
    }
}
