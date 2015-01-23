using NeuralNet.Extensions;
using NeuralNet.Functions;
using NeuralNet.Neurons;
using System.Linq;
using System.Xml.Serialization;

namespace NeuralNet.Layers
{
    public class HiddenLayer : Layer
    {
        /// <summary>
        /// Only for serialization, and casting
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

            if (!(this.PreviousLayer is InputLayer))
            {
                this.PreviousLayer.As<HiddenLayer>().CalculateGradients();
            }
        }

        public static explicit operator HiddenLayer(OutputLayer obj)
        {
            HiddenLayer hl = new HiddenLayer()
            {
                Neurons = obj.Neurons,
                PreviousLayer = obj.PreviousLayer,
                TransferFunction = obj.TransferFunction
            };

            hl.AddBiasNeuron();

            return hl;
        }
    }
}
