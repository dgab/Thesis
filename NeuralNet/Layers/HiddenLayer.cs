using NeuralNet.Functions;
using NeuralNet.Neurons;
using System.Linq;
using System.Xml.Serialization;

namespace NeuralNet.Layers
{
    [XmlRoot("HiddenLayer")]
    public class HiddenLayer : Layer
    {
        /// <summary>
        /// Only for serialization
        /// </summary>
        public HiddenLayer()
            : base()
        {

        }

        public HiddenLayer(Layer previousLayer)
            : base(previousLayer)
        {
            this.TransferFunction = TransferFunctions.Sigmoid;
        }

        public void CalculateGradients()
        {
            foreach (Neuron neuron in this.Neurons.OfType<Neuron>())
            {
                neuron.CalculateHiddenGradient();
            }
        }
    }
}
