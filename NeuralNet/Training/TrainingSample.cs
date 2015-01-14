using System.Collections.Generic;

namespace NeuralNet.Training
{
    public class TrainingSample
    {
        public List<double> Inputs { get; set; }

        public List<double> Targets { get; set; }

        public TrainingSample()
        {
            this.Inputs = new List<double>();
            this.Targets = new List<double>();
        }

        public TrainingSample(List<double> inputs, List<double> targets)
        {
            this.Inputs = inputs;
            this.Targets = targets;
        }

        public void AddInputs(params double[] inputs)
        {
            foreach (double d in inputs)
            {
                this.Inputs.Add(d);
            }
        }

        public void AddTargets(params double[] targets)
        {
            foreach (double d in targets)
            {
                this.Targets.Add(d);
            }
        }
    }
}
