using NeuralNet.Neurons;
using NeuralNet.Others;
using System.Linq;
using System.Xml.Serialization;

namespace NeuralNet.Layers
{
    [XmlRoot("HiddenLayer")]
    public class HiddenLayer : Layer
    {
        /// <summary>
        /// Used for serialization
        /// </summary>
        public HiddenLayer()
            : base()
        {

        }

        public HiddenLayer(Layer previousLayer, IWeightInitializer weightInitializer)
            : base(weightInitializer)
        {
            this.PreviousLayer = previousLayer;
        }

        public HiddenLayer(Layer previousLayer)
            : this(previousLayer, null)
        {

        }

        public void CalculateGradients(Layer nextLayer)
        {
            foreach (Neuron n in this.Neurons)
            {
                foreach (Neuron nln in nextLayer.Neurons)
                {
                    n.Gradient += nln.Weights.First(x => x.Input == n).Weight * nln.Gradient;
                }

                n.Gradient *= this.Function.Derivative(n.Output);
            }
        }
    }
}
