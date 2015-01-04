using NeuralNet.Layers;
using System.Xml.Serialization;

namespace NeuralNet.Neurons
{
    [XmlRoot("BiasNeuron")]
    public class BiasNeuron : Neuron
    {
        /// <summary>
        /// Necessary for serialization.
        /// </summary>
        public BiasNeuron()
        {

        }

        public BiasNeuron(Layer layer)
            :base(layer)
        {
            this.Input = this.Output = 1;
        }

        protected override bool CanCalculateOutput()
        {
            return false;
        }
    }
}
