using NeuralNet.Layers;
using NeuralNet.Others;

namespace NeuralNet.Neurons
{
    /// <summary>
    /// Represents a neuron.
    /// </summary>
    public class Neuron : BaseNeuron
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Neuron"/> class.
        /// </summary>
        /// <param name="currentLayer">The layer on which the neuron should be created.</param>
        public Neuron(Layer currentLayer)
            : base(currentLayer)
        {

        }

        /// <summary>
        /// The gradient of the neuron.
        /// </summary>
        public double Gradient { get; set; }

        /// <summary>
        /// Calculates the gradient of a hidden layer neuron.
        /// </summary>
        public void CalculateHiddenGradient()
        {
            this.Gradient = 0;
            foreach (Synapse s in this.SynapsesOut)
            {
                this.Gradient += s.OutputNeuron.Gradient * s.Weight;
                if (double.IsNaN(this.Gradient))
                {
                    System.Console.WriteLine("asd");
                }
            }
            //this.Gradient *= this.CurrentLayer.Function.ApplyFunction(this.Output);
            this.Gradient *= this.CurrentLayer.Function.Derivative(this.Output);
        }

        /// <summary>
        /// Calculates the gradient of an outputlayer neuron.
        /// </summary>
        /// <param name="target">The target.</param>
        public void CalculateOutputGradient(double target)
        {
            //this.Gradient = (target - this.Output) * this.CurrentLayer.Function.ApplyFunction(this.Output);
            this.Gradient = (target - this.Output) * this.CurrentLayer.Function.Derivative(this.Output);
        }
    }
}
