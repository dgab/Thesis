using NeuralNet.Extensions;
using NeuralNet.Functions;
using NeuralNet.Neurons;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NeuralNet.Layers
{
    [XmlRoot("OutputLayer")]
    public class OutputLayer : Layer
    {
        /// <summary>
        /// Only for serialization
        /// </summary>
        public OutputLayer()
            : base()
        {

        }

        public OutputLayer(Layer previousLayer)
            : base(previousLayer)
        {
            this.TransferFunction = TransferFunctions.Sigmoid;
        }

        protected override bool CanAddBiasNeuron()
        {
            return false;
        }

        public void CalculateGradients(List<double> targets)
        {
            for (int i = 0; i < this.Neurons.Count; i++)
            {
                this.Neurons[i].As<Neuron>().CalculateOutputGradient(targets[i]);
            }
        }
    }
}
