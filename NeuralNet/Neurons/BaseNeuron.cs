using NeuralNet.Layers;
using NeuralNet.Others;
using System.Collections.Generic;

namespace NeuralNet.Neurons
{
    /// <summary>
    /// Abstraction for the <see cref="BiasNeuron"/> and <see cref="Neuron"/> classes..
    /// </summary>
    public abstract class BaseNeuron
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNeuron"/> class.
        /// </summary>
        /// <param name="currentLayer">The layer on which the neuron should be created.</param>
        public BaseNeuron(Layer currentLayer)
        {
            this.CurrentLayer = currentLayer;
            this.SynapsesIn = new List<Synapse>();
            this.SynapsesOut = new List<Synapse>();
        }

        /// <summary>
        /// Gets or sets the layer which the neuron is on.
        /// </summary>
        public Layer CurrentLayer { get; set; }

        /// <summary>
        /// Gets or sets the incoming synapses.
        /// </summary>
        public List<Synapse> SynapsesIn { get; set; }

        /// <summary>
        /// Gets or sets the outgoing synapses.
        /// </summary>
        public List<Synapse> SynapsesOut { get; set; }

        /// <summary>
        /// Gets or sets the input of the neuron.
        /// </summary>
        public double Input { get; set; }

        /// <summary>
        /// Gets or sets the output of the neuron.
        /// </summary>
        public double Output { get; set; }

        /// <summary>
        /// Determines whether or not the neuron can have weights.
        /// </summary>
        /// <returns>The value indicating whether or not the neuron can have weights.</returns>
        public virtual bool CanInitWeight()
        {
            return true;
        }

        /// <summary>
        /// Determines whether or not the neuron can calulate its output.
        /// </summary>
        /// <returns>The value indicating whether or not the neuron can calculate its output.</returns>
        protected virtual bool CanCalculateOutput()
        {
            return true;
        }

        /// <summary>
        /// Calculates the output of the neuron.
        /// </summary>
        protected virtual void OutputCalculation()
        {
            if (!(this.CurrentLayer is InputLayer))
            {
                this.Input = 0;
            }

            foreach (Synapse s in this.SynapsesIn)
            {
                this.Input += s.InputNeuron.Output * s.Weight;
            }

            this.Output = this.CurrentLayer.Function.ApplyFunction(this.Input);
        }

        /// <summary>
        /// If the neuron has the persmission to calculate its output, thn this method calculates it.
        /// </summary>
        public void CalculateOutput()
        {
            if (CanCalculateOutput())
            {
                this.OutputCalculation();
            }
        }

        /// <summary>
        /// Updates the outgoing weights.
        /// </summary>
        public void UpdateWeights()
        {
            foreach (Synapse s in this.SynapsesOut)
            {
                s.Update();
            }
        }
    }
}
