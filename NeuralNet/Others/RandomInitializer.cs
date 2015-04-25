using NeuralNet.Neurons;

namespace NeuralNet.Others
{
    /// <summary>
    /// Represents a weight initializer which can generate random weights.
    /// </summary>
    public class RandomInitializer : IWeightInitializer
    {
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        public double Min { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        public double Max { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomInitializer"/> class.
        /// </summary>
        public RandomInitializer()
        {
            this.Min = -2;
            this.Max = 2;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomInitializer"/> class.
        /// </summary>
        /// <param name="min">The minimum value of the weight.</param>
        /// <param name="max">The maximum value of the weight.</param>
        public RandomInitializer(double min, double max)
        {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// Capable to initialie weights on the given neuron.
        /// </summary>
        /// <param name="n">The given neuron.</param>
        public void InitializeWeights(ref Neuron n)
        {
            throw new System.NotImplementedException();
        }
    }
}
