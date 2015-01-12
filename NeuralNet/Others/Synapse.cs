using NeuralNet.Extensions;
using NeuralNet.Neurons;
using System.Xml.Serialization;

namespace NeuralNet.Others
{
    [XmlRoot("Synapse")]
    public class Synapse
    {
        [XmlIgnore]
        public BaseNeuron InputNeuron { get; set; }

        [XmlIgnore]
        public Neuron OutputNeuron { get; set; }

        [XmlElement("Weight")]
        public double Weight { get; set; }

        [XmlElement("Delta")]
        public double Delta { get; set; }

        [XmlElement("PreviousDelta")]
        public double PreviousDelta { get; set; }

        public void Update()
        {
            this.Delta = NetworkVariables.Eta * this.InputNeuron.Input * this.OutputNeuron.Gradient;
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
