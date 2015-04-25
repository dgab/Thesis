using System;

namespace NeuralNet.Training
{
    /// <summary>
    /// Nem használt.
    /// </summary>
    public class StopTrainingEventArgs : EventArgs
    {
        public bool CancellationPending { get; set; }
        public StopTrainingEventArgs(bool cancellationPending)
        {
            this.CancellationPending = cancellationPending;
        }
    }
}
