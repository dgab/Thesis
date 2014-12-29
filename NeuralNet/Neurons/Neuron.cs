using NeuralNet.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet.Layers;

namespace NeuralNet.Neurons
{
    public class Neuron : BaseNeuron
    {
        public double Input {get; set;}

        public Dictionary<BaseNeuron, double> Weights { get; set; }

        private IWeightInitializer WeightInitializer;

        public Neuron(Layer layer)
            :base(layer)
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
    }
}
