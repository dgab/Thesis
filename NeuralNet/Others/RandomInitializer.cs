using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet;
using NeuralNet.Layers;
using NeuralNet.Extensions;
using NeuralNet.Neurons;

namespace NeuralNet.Others
{
    public class RandomInitializer : IWeightInitializer
    {
        public double Min { get; set; }
        public double Max { get; set; }

        private readonly Random random;
        public RandomInitializer()
        {
            Min = -2;
            Max = 2;
            random = new Random();
        }
        public Dictionary<BaseNeuron, double> Initialize(Layer previousLayer)
        {
            Dictionary<BaseNeuron, double> weights = new Dictionary<BaseNeuron, double>();

            foreach (BaseNeuron neuron in previousLayer.Neurons)
            {
                weights.Add(neuron, random.NextDouble(Min, Max));
            }

            return weights;
        }
    }
}
