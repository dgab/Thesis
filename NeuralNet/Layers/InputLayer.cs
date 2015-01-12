using NeuralNet.Functions;
using NeuralNet.Neurons;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NeuralNet.Layers
{
    [XmlRoot("InputLayer")]
    public class InputLayer : Layer
    {
        public InputLayer()
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

        public override void CalculateOutputs()
        {
            //Do nothing at all....
        }
    }
}
