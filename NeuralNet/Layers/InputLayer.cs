using NeuralNet.Functions;
using NeuralNet.Neurons;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

namespace NeuralNet.Layers
{
    [XmlRoot("InputLayer")]
    public class InputLayer : Layer
    {
        public InputLayer()
            :base()
        {
            this.TransferFunction = TransferFunctions.Identity;
        }

        public void ApplyTrainingSet(TrainingSet ts)
        {
            //first is biasneuron....always
            for (int i = 0; i < this.Neurons.Count - 1; i++)
            {
                this.Neurons[i + 1].Input = ts.Inputs[i];
            }
        }
    }
}
