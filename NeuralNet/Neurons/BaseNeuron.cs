using NeuralNet.Layers;
using NeuralNet.Others;
using System.Collections.Generic;

namespace NeuralNet.Neurons
{
    public class BaseNeuron
    {
        public BaseNeuron(Layer currentLayer)
        {
            this.CurrentLayer = currentLayer;
            this.SynapsesIn = new List<Synapse>();
            this.SynapsesOut = new List<Synapse>();
        }
        public Layer CurrentLayer { get; set; }

        public List<Synapse> SynapsesIn { get; set; }

        public List<Synapse> SynapsesOut { get; set; }

        public double Input { get; set; }

        public double Output { get; set; }

        public virtual bool CanInitWeight()
        {
            return true;
        }

        protected virtual bool CanCalculateOutput()
        {
            return true;
        }
        protected virtual void OutputCalculation()
        {
            if (!(this.CurrentLayer is InputLayer))
            {
                this.Input = 0;
            }

            foreach (Synapse s in this.SynapsesIn)
            {
                this.Input += s.InputNeuron.Output * s.Weight;
            }

            this.Output = this.CurrentLayer.Function.ApplyFunction(this.Input);
        }

        public void CalculateOutput()
        {
            if (CanCalculateOutput())
            {
                this.OutputCalculation();
            }
        }

        public void UpdateWeights()
        {
            foreach (Synapse s in this.SynapsesOut)
            {
                s.Update();
            }
        }
    }
}
