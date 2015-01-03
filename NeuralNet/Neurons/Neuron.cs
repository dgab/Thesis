using NeuralNet.Layers;
using NeuralNet.Others;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet.Neurons
{
    public class Neuron : BaseNeuron
    {
        public double Input { get; set; }

        public Dictionary<BaseNeuron, double> Weights { get; set; }

        private IWeightInitializer WeightInitializer;

        public Neuron(Layer layer)
            : base(layer)
        {
            Weights = new Dictionary<BaseNeuron, double>();
            WeightInitializer = new RandomInitializer();
        }

        public void CalculateOutput(Layer previousLayer)
        {
            foreach (BaseNeuron n in previousLayer.Neurons)
            {
                this.Input += n.Output * Weights[n];
            }

            this.Output = this.Layer.Function.ApplyFunction(this.Input);
        }

        public void CalculateOutput()
        {
            this.Output = this.Input;
        }

        public void InitializeWeights(Layer previousLayer)
        {
            Weights = WeightInitializer.Initialize(previousLayer);
        }

        public void CalculateDelta(double eta)
        {
            foreach (BaseNeuron key in Weights.Keys.ToList())
            {
                Weights[key] += eta * this.Gradient * key.Output;
            }
        }


    }
}
