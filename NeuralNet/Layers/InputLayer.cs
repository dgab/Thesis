
namespace NeuralNet.Layers
{
    public class InputLayer : Layer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:InputLayer"/> class.
        /// </summary>
        public InputLayer()
            : base()
        {
        }

        public InputLayer(bool withBias)
            : base(withBias)
        {

        }

        public InputLayer(int neurons)
            : base(neurons)
        {

        }
    }
}
