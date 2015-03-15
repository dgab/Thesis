using NeuralNet.Layers;
using NeuralNet.Others;

namespace NeuralNet.Neurons
{
    public class Neuron : BaseNeuron
    {
        public Neuron(Layer currentLayer)
            : base(currentLayer)
        {

        }


        public double Gradient { get; set; }

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

        public void CalculateOutputGradient(double target)
        {
            //this.Gradient = (target - this.Output) * this.CurrentLayer.Function.ApplyFunction(this.Output);
            this.Gradient = (target - this.Output) * this.CurrentLayer.Function.Derivative(this.Output);
        }
    }
}
