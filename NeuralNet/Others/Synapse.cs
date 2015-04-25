using NeuralNet.Extensions;
using NeuralNet.Neurons;

namespace NeuralNet.Others
{
    /// <summary>
    /// Represent a synapse.
    /// </summary>
    public class Synapse
    {
        /// <summary>
        /// Gets or sets the neuron which the synapse starts from.
        /// </summary>
        public BaseNeuron InputNeuron { get; set; }

        /// <summary>
        /// Gets or sets the neuron which the synapse ends in.
        /// </summary>
        public Neuron OutputNeuron { get; set; }

        /// <summary>
        /// Gets or sets the weight of the synapse.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the Delta.
        /// </summary>
        public double Delta { get; set; }

        /// <summary>
        /// Gets or sets the delta from the previous iteration.
        /// </summary>
        public double PreviousDelta { get; set; }

        /// <summary>
        /// Updates the weight.
        /// </summary>
        public void Update()
        {
            this.Delta = NetworkVariables.Eta * this.InputNeuron.Input * this.OutputNeuron.Gradient;
            this.Weight += this.Delta;
            this.Weight += NetworkVariables.Momentum * this.PreviousDelta;
            this.PreviousDelta = this.Delta;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Synapse"/> class.
        /// Only for serializiation.
        /// </summary>
        public Synapse()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Synapse"/> class..
        /// </summary>
        /// <param name="inputNeuron">The input neuron.</param>
        /// <param name="outputNeuron">The output neuron..</param>
        public Synapse(BaseNeuron inputNeuron, Neuron outputNeuron)
        {
            this.InputNeuron = inputNeuron;
            this.OutputNeuron = outputNeuron;
        }

        /// <summary>
        /// Initializes the weight.
        /// </summary>
        public void InitializeWeight()
        {
            this.Weight = RandomExtensions.Default.NextDouble(-2, 2);
        }
    }
}
