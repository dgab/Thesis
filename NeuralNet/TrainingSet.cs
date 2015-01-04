using System.Collections.Generic;
using System.Xml.Serialization;

namespace NeuralNet
{
    [XmlRoot("TrainingSet")]
    public class TrainingSet
    {
        [XmlArray("Inputs")]
        [XmlArrayItem("Input")]
        public List<double> Inputs { get; set; }

        [XmlArray("Targets")]
        [XmlArrayItem("Target")]
        public List<double> Targets { get; set; }

        public TrainingSet()
        {
            this.Inputs = new List<double>();
            this.Targets = new List<double>();
        }

        public TrainingSet(List<double> inputs, List<double> targets)
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
