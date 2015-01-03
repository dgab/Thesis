using NeuralNet.Extensions;
using NeuralNet.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet.Layers
{
    public class OutputLayer : Layer, ILayer
    {
        public Layer PreviousLayer { get; set; }

        public OutputLayer(Layer previousLayer, bool withBias)
            : base(withBias)
        {
            this.PreviousLayer = previousLayer;
        }

        public OutputLayer(Layer previousLayer)
            : this(previousLayer, true)
        {

        }
        public OutputLayer(Layer previousLayer, int neurons)
            : base(neurons)
        {
            this.PreviousLayer = previousLayer;
        }

        public void InitializeWeights()
        {
            foreach (BaseNeuron n in this.Neurons.OfType<Neuron>())
            {
                n.As<Neuron>().InitializeWeights(PreviousLayer);
            }
        }

        public override void CalculateOutputs()
        {
            foreach (BaseNeuron n in Neurons.OfType<Neuron>())
            {
                n.As<Neuron>().CalculateOutput(PreviousLayer);
            }
        }

        public void CalculateGradients(List<double> targets)
        {
            if (this.SimpleNeurons.Count != targets.Count)
            {
                throw new ArgumentException("Invalid amount of target values.");
            }

            foreach (Neuron n in this.SimpleNeurons)
            {
                n.Gradient = this.Function.Derivative(n.Output) * (targets[SimpleNeurons.IndexOf(n)] - n.Output);
            }
        }

        public void CalculateDeltas(double eta)
        {
            this.SimpleNeurons.ForEach(x => x.CalculateDelta(eta));
        }
    }
}
