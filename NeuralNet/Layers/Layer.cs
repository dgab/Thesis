using NeuralNet.Functions;
using NeuralNet.Neurons;
using NeuralNet.Others;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet.Layers
{
    /// <summary>
    /// AAbstraction for the <see cref="InputLayer"/>, <see cref="HiddenLayer"/> and <see cref="OutputLayer"/> classes.
    /// </summary>
    public abstract class Layer
    {
        private TransferFunctions transferFunction;

        /// <summary>
        /// EInitializes a new instance of the <see cref="Layer"/> class.
        /// </summary>
        /// <param name="previousLayer">The previous layer.</param>
        public Layer(Layer previousLayer)
        {
            this.PreviousLayer = previousLayer;
            this.Neurons = new List<BaseNeuron>();

            if (CanAddBiasNeuron())
            {
                this.AddBiasNeuron();
            }
        }

        /// <summary>
        /// Gets the activation function.
        /// </summary>
        public IFunction Function { get; private set; }

        /// <summary>
        /// Gets the number of neurons on the current layer.
        /// </summary>
        public List<BaseNeuron> Neurons { get; protected set; }

        /// <summary>
        /// Gets or sets the previous layer.
        /// </summary>
        public Layer PreviousLayer { get; set; }

        /// <summary>
        /// Gets or sets which activation funtion should be used on the current layer.
        /// </summary>
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

        /// <summary>
        /// Calculates the outputs for the neurons on the current layer.
        /// </summary>
        public virtual void CalculateOutputs()
        {
            foreach (BaseNeuron neuron in this.Neurons)
            {
                neuron.CalculateOutput();
            }
        }

        /// <summary>
        /// Initializes the weight on the current layer.
        /// </summary>
        public void InitializeWeights()
        {
            if (CanInitializeWeights())
            {
                InitWeights();
            }
        }

        /// <summary>
        /// Updates the weights on the current layer.
        /// </summary>
        public void UpdateWeights()
        {
            foreach (BaseNeuron neuron in this.Neurons)
            {
                neuron.UpdateWeights();
            }
        }

        /// <summary>
        /// Determines whether or not the current layer can have a bias neuron.
        /// </summary>
        /// <returns>True</returns>
        protected virtual bool CanAddBiasNeuron()
        {
            return true;
        }

        /// <summary>
        /// Determines whether or not weights can be initialized on the current layer.
        /// </summary>
        /// <returns></returns>
        protected virtual bool CanInitializeWeights()
        {
            return true;
        }

        /// <summary>
        /// Initializes the weights between the neurons on the current layer and the neurons on the previous layer.
        /// </summary>
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
        #region Neuron adding/removing methods

        /// <summary>
        /// Adds a neuron to the layer.
        /// </summary>
        public void AddNeuron()
        {
            this.Neurons.Add(new Neuron(this));
        }

        /// <summary>
        /// Adds a number of neurons to the layer.
        /// </summary>
        /// <param name="amount">The given number of neuron to be added.</param>
        public void AddNeurons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                this.Neurons.Add(new Neuron(this));
            }
        }

        /// <summary>
        /// Deletes a specific neuron.
        /// </summary>
        /// <param name="n"></param>
        public void RemoveNeuron(Neuron n)
        {
            this.Neurons.Remove(n);
        }

        /// <summary>
        /// Adds a bias to the layer.
        /// </summary>
        protected void AddBiasNeuron()
        {
            this.Neurons.Insert(0, new BiasNeuron(this));
        }

        #endregion Neuron adding/removing methods
    }
}