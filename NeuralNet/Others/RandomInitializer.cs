using NeuralNet.Neurons;

namespace NeuralNet.Others
{
    public class RandomInitializer : IWeightInitializer
    {
        public double Min { get; set; }

        public double Max { get; set; }

        public RandomInitializer()
        {
            this.Min = -2;
            this.Max = 2;
        }

        public RandomInitializer(double min, double max)
        {
            this.Min = min;
            this.Max = max;
        }

        public double InitializeWeight()
        {
            return 0;
        }

        public void InitializeWeights(ref Neuron n)
        {
            throw new System.NotImplementedException();
        }
    }
}
