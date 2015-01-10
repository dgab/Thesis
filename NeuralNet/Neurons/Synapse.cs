using System;
using System.Xml.Serialization;

namespace NeuralNet.Neurons
{
    [Serializable()]
    [XmlRoot("Weight")]
    public class Synapse
    {
        [XmlIgnore()]
        public Neuron Input { get; set; }

        [XmlIgnore()]
        public Neuron Output { get; set; }

        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlElement("Weight")]
        public double Weight { get; set; }

        [XmlElement("Delta")]
        public double Delta { get; set; }

        [XmlElement("PreviousDelta")]
        public double PreviousDelta { get; set; }

        public Synapse(Neuron input, Neuron output)
        {
            this.Input = input;
            this.Output = output;
            this.PreviousDelta = 0;
        }

        /// <summary>
        /// Parameterless constructor for serialization.
        /// </summary>
        public Synapse()
        {
        }

        public void Update()
        {
            this.Delta = NetworkVariables.Eta * this.Output.Gradient * this.Input.Input;
            this.Weight += this.Delta;
            this.Weight += this.PreviousDelta * NetworkVariables.Momentum;
            this.PreviousDelta = this.Delta;
        }
    }
}
