using System.Collections.Generic;

namespace NeuralNet.Training
{
    /// <summary>
    /// Represents a training sample.
    /// </summary>
    public class TrainingSample
    {
        /// <summary>
        /// The inputs of the sample.
        /// </summary>
        public List<double> Inputs { get; set; }

        /// <summary>
        /// The targets of the sample.
        /// </summary>
        public List<double> Targets { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingSample"/> class.
        /// </summary>
        public TrainingSample()
        {
            this.Inputs = new List<double>();
            this.Targets = new List<double>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingSample"/> class.
        /// </summary>
        /// <param name="inputs">The inputs.</param>
        /// <param name="targets">The targets.</param>
        public TrainingSample(List<double> inputs, List<double> targets)
        {
            this.Inputs = inputs;
            this.Targets = targets;
        }

        /// <summary>
        /// Adds an array of input values to the input collection.
        /// </summary>
        /// <param name="inputs">The input array.</param>
        public void AddInputs(params double[] inputs)
        {
            foreach (double d in inputs)
            {
                this.Inputs.Add(d);
            }
        }

        /// <summary>
        /// Adds an array of target values to the input collection.
        /// </summary>
        /// <param name="targets">The target array.</param>
        public void AddTargets(params double[] targets)
        {
            foreach (double d in targets)
            {
                this.Targets.Add(d);
            }
        }

        /// <summary>
        /// Overridden ToString.
        /// </summary>
        /// <returns>Always "Training Sample"</returns>
        public override string ToString()
        {
            return "Training Sample";
        }
    }
}
