using NeuralNet.Layers;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NeuralNet.Neurons
{
    [XmlRoot("Neuron")]
    [XmlInclude(typeof(BiasNeuron))]
    public class Neuron
    {
        [XmlAttribute("input")]
        public double Input { get; set; }

        [XmlAttribute("output")]
        public double Output { get; set; }

        [XmlArray("Weights")]
        [XmlArrayItem("Weight")]
        public List<Synapse> Weights { get; set; }

        [XmlElement("Gradient")]
        public double Gradient { get; set; }

        [XmlIgnore()]
        public Layer Layer { get; set; }

        /// <summary>
        /// Should only be used during serialization.
        /// </summary>
        public Neuron()
        {
            this.Weights = new List<Synapse>();
        }

        public Neuron(Layer layer)
            :this()
        {
            this.Layer = layer;
        }

        #region FeedForward
        protected virtual bool CanCalculateOutput()
        {
            return true;
        }

        public void CalculateOutput()
        {
            if (CanCalculateOutput())
            {
                foreach (Synapse w in this.Weights)
                {
                    this.Input += w.Input.Output * w.Weight;
                }
                this.Output = this.Layer.Function.ApplyFunction(this.Input);
            }
        }

        #endregion

        #region Backprop

        #endregion
    }
}
