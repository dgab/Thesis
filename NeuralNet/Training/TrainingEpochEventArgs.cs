using System;

namespace NeuralNet.Training
{
    public class TrainingEpochEventArgs : EventArgs
    {
        public int CurrentIteration { get; set; }
        public double Error { get; set; }
        public TrainingEpochEventArgs(double error, int currentIteration)
        {
            this.Error = error;
            this.CurrentIteration = currentIteration;
        }
    }
}
