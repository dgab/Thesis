using NeuralNet.Extensions;
using NeuralNet.Functions;
using NeuralNet.Neurons;
using System.Linq;

namespace NeuralNet.Layers
{
    public class HiddenLayer : Layer
    {

        public HiddenLayer(Layer previousLayer)
            : base(previousLayer)
        {
            this.TransferFunction = TransferFunctions.Sigmoid;
        }

        public void CalculateGradients()
        {
            foreach (Neuron neuron in this.Neurons.OfType<Neuron>())
            {
                neuron.CalculateHiddenGradient();
            }

            if (!(this.PreviousLayer is InputLayer))
            {
                this.PreviousLayer.As<HiddenLayer>().CalculateGradients();
            }
        }

        public static explicit operator HiddenLayer(OutputLayer obj)
        {
            HiddenLayer hl = new HiddenLayer(obj.PreviousLayer)
            {
                Neurons = obj.Neurons,
                TransferFunction = obj.TransferFunction
            };
            hl.Neurons.ForEach(x => x.CurrentLayer = hl);
            hl.AddBiasNeuron();

            return hl;
        }
    }
}
