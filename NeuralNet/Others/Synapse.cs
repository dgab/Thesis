using NeuralNet.Extensions;
using NeuralNet.Neurons;

namespace NeuralNet.Others
{
    public class Synapse
    {
        public BaseNeuron InputNeuron { get; set; }

        public Neuron OutputNeuron { get; set; }

        public double Weight { get; set; }

        public double Delta { get; set; }

        public double PreviousDelta { get; set; }

        public void Update()
        {
            this.Delta = NetworkVariables.Eta * this.InputNeuron.Output * this.OutputNeuron.Gradient;
            this.Weight += this.Delta;
            this.Weight += NetworkVariables.Momentum * this.PreviousDelta;
            this.PreviousDelta = this.Delta;
        }

        /// <summary>
        /// Only for serialization
        /// </summary>
        public Synapse()
        {

        }

        public Synapse(BaseNeuron inputNeuron, Neuron outputNeuron)
        {
            this.InputNeuron = inputNeuron;
            this.OutputNeuron = outputNeuron;
        }

        public void InitializeWeight()
        {
            this.Weight = RandomExtensions.Default.NextDouble(-2, 2);
        }
    }
}
