using NeuralNet.Extensions;
using NeuralNet.Functions;
using NeuralNet.Neurons;
using System.Linq;

namespace NeuralNet.Layers
{
    /// <summary>
    /// Represents the hidden layer.
    /// </summary>
    public class HiddenLayer : Layer
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="HiddenLayer"/> class.
        /// </summary>
        /// <param name="previousLayer">The previous layer.</param>
        public HiddenLayer(Layer previousLayer)
            : base(previousLayer)
        {
            this.TransferFunction = TransferFunctions.Sigmoid;
        }

        /// <summary>
        /// Calculates the gradient values for the neurons on the current layer.
        /// </summary>
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

        /// <summary>
        /// Casts a <see cref="HiddenLayer"/> instance to a <see cref="OutputLayer"/> class.
        /// </summary>
        /// <param name="obj">An outputlayer </param>
        /// <returns></returns>
        public static explicit operator HiddenLayer(OutputLayer obj)
        {
            HiddenLayer hl = new HiddenLayer(obj.PreviousLayer)
            {
                Neurons = obj.Neurons,
                TransferFunction = obj.TransferFunction
            };
            hl.Neurons.ForEach(x => x.CurrentLayer = hl);
            hl.AddBiasNeuron();

            return hl;
        }
    }
}
