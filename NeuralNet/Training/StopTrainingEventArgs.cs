using System;

namespace NeuralNet.Training
{
    public class StopTrainingEventArgs : EventArgs
    {
        public bool CancellationPending { get; set; }
        public StopTrainingEventArgs(bool cancellationPending)
        {
            this.CancellationPending = cancellationPending;
        }
    }
}
