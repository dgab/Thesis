
namespace NeuralNet.Layers
{
    public interface ILayer
    {
        Layer PreviousLayer { get; set; }

        void InitializeWeights();
    }
}
