using NeuralNet.Layers;
using NeuralNet.Others;
using System.Xml.Serialization;

namespace NeuralNet.Neurons
{
    [XmlRoot("Neuron")]
    public class Neuron : BaseNeuron
    {

        /// <summary>
        /// Only for serialization
        /// </summary>
        public Neuron()
        {

        }

        public Neuron(Layer currentLayer)
            : base(currentLayer)
        {

        }


        [XmlElement("Gradient")]
        public double Gradient { get; set; }

        public void CalculateHiddenGradient()
        {
            foreach (Synapse s in this.SynapsesOut)
            {
                this.Gradient += s.OutputNeuron.Gradient * s.Weight;
            }
            this.Gradient *= this.CurrentLayer.Function.ApplyFunction(this.Output);
        }

        public void CalculateOutputGradient(double target)
        {
            this.Gradient = (target - this.Output) * this.CurrentLayer.Function.ApplyFunction(this.Output);
        }
    }
}
