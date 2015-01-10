using NeuralNet.Neurons;
using NeuralNet.Others;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NeuralNet.Layers
{
    public class OutputLayer : Layer
    {
        [XmlIgnore()]
        List<double> Targets { get; set; }
        /// <summary>
        /// Used for serialization
        /// </summary>
        public OutputLayer()
            : base()
        {

        }

        public OutputLayer(Layer previousLayer, IWeightInitializer weightInitializer)
            : base(weightInitializer)
        {
            this.PreviousLayer = previousLayer;
        }

        public OutputLayer(Layer previousLayer)
            : this(previousLayer, null)
        {

        }

        protected override bool CanAddBiasNeuron()
        {
            return false;
        }

        public void ApplyTrainingSet(TrainingSet ts)
        {
            this.Targets = ts.Targets;
        }

        public void CalculateGradients()
        {
            foreach (Neuron n in this.Neurons)
            {
                n.Gradient = (this.Targets[this.Neurons.IndexOf(n)] - n.Output) * this.Function.Derivative(n.Output);
            }
        }

        public double CalculateError()
        {
            double error = 0;

            foreach (Neuron n in this.Neurons)
            {
                error += Math.Pow(this.Targets[this.Neurons.IndexOf(n)] - n.Output, 2);
            }

            error /= this.Neurons.Count;

            return error;
        }
    }
}
