using NeuralNet.Others;

namespace NeuralNet.Layers
{
    public class OutputLayer : Layer
    {
        /// <summary>
        /// Used for serialization
        /// </summary>
        public OutputLayer()
            :base()
        {

        }

        public OutputLayer(Layer previousLayer, IWeightInitializer weightInitializer)
            :base(weightInitializer)
        {
            this.PreviousLayer = previousLayer;
        }

        public OutputLayer(Layer previousLayer)
            :this(previousLayer, null)
        {

        }

        protected override bool CanAddBiasNeuron()
        {
            return false;
        }
    }
}
