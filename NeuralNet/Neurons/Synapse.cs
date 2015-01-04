using NeuralNet.Neurons;
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

        public Synapse(Neuron input, Neuron output)
        {
            this.Input = input;
            this.Output = output;
        }

        /// <summary>
        /// Parameterless constructor for serialization.
        /// </summary>
        public Synapse()
        {

        }
    }
}
