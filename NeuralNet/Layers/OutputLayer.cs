using NeuralNet.Extensions;
using NeuralNet.Functions;
using NeuralNet.Neurons;
using System;
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

    }
}
