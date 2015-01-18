using NeuralNet.Layers;
using NeuralNet.Others;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NeuralNet.Neurons
{
    [XmlRoot("BaseNeuron")]
    [XmlInclude(typeof(BiasNeuron)),
     XmlInclude(typeof(Neuron))]
    public class BaseNeuron
    {
        /// <summary>
        /// Only for serialization
        /// </summary>
        public BaseNeuron()
        {

        }

        public BaseNeuron(Layer currentLayer)
        {
            this.CurrentLayer = currentLayer;
            this.SynapsesIn = new List<Synapse>();
            this.SynapsesOut = new List<Synapse>();
        }

        [XmlIgnore]
        public Layer CurrentLayer { get; set; }

        //[XmlArray("InputSynapses"), XmlArrayItem("Synapse")]
        [XmlIgnore]
        public List<Synapse> SynapsesIn { get; set; }

        [XmlArray("OutputSynapses"), XmlArrayItem("Synapse")]
        public List<Synapse> SynapsesOut { get; set; }

        [XmlElement("Input")]
        public double Input { get; set; }

        [XmlElement("Output")]
        public double Output { get; set; }

        /*public bool ResetInput
        {
            get
            {
                return this.CurrentLayer.GetType() != typeof(InputLayer);
            }
        }*/
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
