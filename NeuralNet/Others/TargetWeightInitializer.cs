using NeuralNet.Layers;
using NeuralNet.Neurons;

namespace NeuralNet.Others
{
    public class TargetWeightInitializer : IWeightInitializer
    {
        public void InitializeWeights(ref Neuron n)
        {
            Layer previousLayer = n.Layer.PreviousLayer;
            int index = n.Layer.Neurons.IndexOf(n);

            Synapse s = new Synapse(previousLayer.Neurons[index], n);
            s.Index = 0;
            s.Weight = 1;
            n.Weights.Add(s);
        }
    }
}
