using NeuralNet.Extensions;
using NeuralNet.Layers;
using NeuralNet.Neurons;
using System;

namespace NeuralNet.Others
{
    public class RandomInitializer : IWeightInitializer
    {
        public double Min { get; set; }

        public double Max { get; set; }

        public RandomInitializer()
        {
            this.Min = -2;
            this.Max = 2;
        }

        public RandomInitializer(double min, double max)
        {
            this.Min = min;
            this.Max = max;
        }

        public void InitializeWeights(ref Neuron neuron)
        {
            Layer previousLayer = neuron.Layer.PreviousLayer;

            foreach (Neuron previousNeuron in previousLayer.Neurons)
            {
                Synapse s = new Synapse(previousNeuron, neuron);
                s.Weight = RandomExtensions.GetRandom.NextDouble(this.Min, this.Max);
                s.Index = previousLayer.Neurons.IndexOf(previousNeuron);
                neuron.Weights.Add(s);
            }
        }
    }
}
