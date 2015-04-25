using NeuralNet.Functions;
using NeuralNet.Neurons;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet.Layers
{
    /// <summary>
    /// Represents the input layer.
    /// </summary>
    public class InputLayer : Layer
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InputLayer"/> class.
        /// </summary>
        public InputLayer()
            : base(null)
        {
            this.Neurons = new List<BaseNeuron>();

            if (CanAddBiasNeuron())
            {
                this.AddBiasNeuron();
            }

            this.TransferFunction = TransferFunctions.Identity;
        }

        /// <summary>
        /// Determines whether or not weights can be initializes on the current layer.
        /// </summary>
        /// <returns>False</returns>
        protected override bool CanInitializeWeights()
        {
            return false;
        }

        /// <summary>
        /// Adds input values to the neuron on the current layer.
        /// </summary>
        /// <param name="inputs">The inputs.</param>
        public void AddInputs(List<double> inputs)
        {
            int i = 0;
            foreach (Neuron n in this.Neurons.OfType<Neuron>())
            {
                n.Input = inputs[i];
                i++;
            }
        }
    }
}
