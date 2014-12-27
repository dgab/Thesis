using NeuralNet.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet.Layers;

namespace NeuralNet
{
    public class Neuron
    {
        public double Input {get; set;}
        public double Output {get; set;}

        public Dictionary<Neuron, double> Weights { get; set; }

        private IWeightInitializer WeightInitializer;

        private Layer Layer;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Neuron"/> class.
        /// </summary>
        public Neuron(Layer layer)
        {
            this.Layer = layer;
            Weights = new Dictionary<Neuron, double>();
            WeightInitializer = new RandomInitializer();
        }

        public void CalculateOutput(Layer previousLayer)
        {
            foreach (Neuron n in previousLayer.Neurons)
            {
                this.Input += n.Output * Weights[n];
            }

            this.CalculateOutput();
        }

        public void CalculateOutput()
        {
            this.Output = this.Layer.Function.ApplyFunction(this.Input);
        }

        public void InitializeWeights(Layer previousLayer)
        {
            Weights = WeightInitializer.Initialize(previousLayer, this);
        }
    }
}
