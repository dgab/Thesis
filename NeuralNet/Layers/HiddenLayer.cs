using NeuralNet.Others;
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
            :base()
        {

        }

        public HiddenLayer(Layer previousLayer, IWeightInitializer weightInitializer)
            :base(weightInitializer)
        {
            this.PreviousLayer = previousLayer;
        }

        public HiddenLayer(Layer previousLayer)
            :this(previousLayer, null)
        {

        }
    }
}
