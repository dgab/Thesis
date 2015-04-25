using System;

namespace NeuralNet.Training
{
    /// <summary>
    /// Stores information about a training iteration.
    /// </summary>
    public class TrainingEpochEventArgs : EventArgs
    {
        /// <summary>
        /// The number of the iteration.
        /// </summary>
        public int CurrentIteration { get; set; }

        /// <summary>
        /// The level of the error.
        /// </summary>
        public double Error { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingEpochEventArgs"/> class.
        /// </summary>
        /// <param name="error">The level of the error.</param>
        /// <param name="currentIteration">The number of the iteration.</param>
        public TrainingEpochEventArgs(double error, int currentIteration)
        {
            this.Error = error;
            this.CurrentIteration = currentIteration;
        }
    }
}
