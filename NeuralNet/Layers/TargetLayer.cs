using NeuralNet.Functions;
using NeuralNet.Neurons;
using NeuralNet.Others;

namespace NeuralNet.Layers
{
    public class TargetLayer : Layer
    {
        public TargetLayer()
            :base(new TargetWeightInitializer())
        {

        }

        public TargetLayer(Layer previousLayer)
            :this()
        {
            this.PreviousLayer = previousLayer;
            this.TransferFunction = TransferFunctions.Identity;
        }

        protected override bool CanAddBiasNeuron()
        {
            return false;
        }

        public override void CalculateOutputs()
        {
            foreach (Neuron n in this.Neurons)
            {
                n.Output = n.Input;
            }
        }

        public void ApplyTrainingSet(TrainingSet ts)
        {
            for (int i = 0; i < this.Neurons.Count; i++)
            {
                this.Neurons[i].Input = ts.Targets[i];
            }
        }
    }
}
