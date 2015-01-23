using NeuralNet.Functions;
using NeuralNet.Neurons;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet.Layers
{
    public class InputLayer : Layer
    {
        public InputLayer()
            : base(null)
        {
            this.Neurons = new List<BaseNeuron>();

            if (CanAddBiasNeuron())
            {
                this.AddBiasNeuron();
            }

            this.TransferFunction = TransferFunctions.Identity;
        }


        protected override bool CanInitializeWeights()
        {
            return false;
        }

        public void AddInputs(List<double> inputs)
        {
            int i = 0;
            foreach (Neuron n in this.Neurons.OfType<Neuron>())
            {
                n.Input = inputs[i];
                i++;
            }
        }
    }
}
