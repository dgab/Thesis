using System.Collections.Generic;

namespace NeuralNet.Training
{
    public class TrainingSet
    {
        public List<TrainingSample> TrainingSamples { get; set; }

        public TrainingSet()
        {
            this.TrainingSamples = new List<TrainingSample>();
        }
    }
}
