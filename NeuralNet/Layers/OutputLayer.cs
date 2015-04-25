using NeuralNet.Extensions;
using NeuralNet.Functions;
using NeuralNet.Neurons;
using System;
using System.Collections.Generic;

namespace NeuralNet.Layers
{
    /// <summary>
    /// Represents an output layer.
    /// </summary>
    public class OutputLayer : Layer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputLayer"/> class.
        /// </summary>
        /// <param name="previousLayer">The previous layer.</param>
        public OutputLayer(Layer previousLayer)
            : base(previousLayer)
        {
            this.TransferFunction = TransferFunctions.Sigmoid;
        }

        /// <summary>
        /// Determines whether or not a bias neuron can be initialized on this layer.
        /// </summary>
        /// <returns>False</returns>
        protected override bool CanAddBiasNeuron()
        {
            return false;
        }

        /// <summary>
        /// Calculates the gradient for each neuron on the current layer.
        /// </summary>
        /// <param name="targets">Az elvárt kimeneti értékek.</param>
        /// <returns></returns>
        public double CalculateGradients(List<double> targets)
        {
            double error = 0;
            for (int i = 0; i < this.Neurons.Count; i++)
            {
                error += Math.Pow(targets[i] - this.Neurons[i].Output, 2);
                this.Neurons[i].As<Neuron>().CalculateOutputGradient(targets[i]);
            }

            if (!(this.PreviousLayer is InputLayer))
            {
                this.PreviousLayer.As<HiddenLayer>().CalculateGradients();
            }

            return error;
        }

        /// <summary>
        /// Calculates the error level for the given targets.
        /// </summary>
        /// <param name="targets">The targets.</param>
        /// <returns>AThe level of the error.</returns>
        public double CalculateError(List<double> targets)
        {
            double error = 0;

            for (int i = 0; i < this.Neurons.Count; i++)
            {
                error += Math.Pow(targets[i] - this.Neurons[i].Output, 2);
            }

            return error;
        }
    }
}
