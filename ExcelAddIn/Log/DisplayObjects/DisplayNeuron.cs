using NeuralNet.Neurons;
using System;
using System.ComponentModel;
using System.Windows.Media;
namespace ExcelAddIn.Log
{
    [DisplayName("Ellipse")]
    [Description("This element represents a neuron in the network.")]
    public class DisplayNeuron : DisplayObject
    {
        private double x;

        [Category("Display")]
        [DisplayName("X")]
        [Description("Gets the X coordinate of the ellipse.")]
        public override double X
        {
            get { return x; }
            set
            {
                if (value > 0)
                {
                    x = (Math.Round(value / 50.0)) * 50;
                    OnPropertyChanged("X");
                }
            }
        }

        private double y;

        [Category("Display")]
        [DisplayName("Y")]
        [Description("Gets the Y coordinate of the ellipse.")]
        public override double Y
        {
            get { return y; }
            set
            {
                if (value > 0)
                {
                    y = (Math.Round(value / 50.0)) * 50;
                    OnPropertyChanged("Y");
                }
            }
        }

        private bool isHighlighted { get; set; }

        [Browsable(false)]
        public bool IsHighlighted
        {
            get
            {
                return isHighlighted;
            }
            set
            {
                isHighlighted = value;
                OnPropertyChanged("IsHighlighted");
            }
        }

        [Browsable(false)]
        public BaseNeuron Neuron { get; set; }

        [Category("Neuron")]
        [DisplayName("Input")]
        [Description("Gets the Input of the neuron")]
        public string Input
        {
            get
            {
                return Neuron.Input.ToString("N3");
            }
        }

        [Category("Neuron properties")]
        [DisplayName("Output")]
        [Description("Gets the Output of the neuron")]
        public string Output
        {
            get
            {
                return Neuron.Output.ToString("N3");
            }
        }

        [Category("Neuron properties")]
        [DisplayName("Type")]
        [Description("Gets the Type of the neuron")]
        public string Type
        {
            get
            {
                return Neuron.GetType().Name;
            }
        }

        [Category("Neuron properties")]
        [DisplayName("Current Layer")]
        [Description("Gets the Current Layer of the neuron")]
        public string LayerType
        {
            get
            {
                return this.Neuron.CurrentLayer.GetType().Name;
            }
        }

        /*[Category("Neuron properties")]
        [DisplayName("Input Synapses")]
        [Description("Gets the Input Synapses of the neuron")]
        public List<Synapse> InputSynapses
        {
            get
            {
                return Neuron.SynapsesIn;
            }
        }

        [Category("Neuron properties")]
        [DisplayName("Output Synapses")]
        [Description("Gets the Output Synapses of the neuron")]
        public List<Synapse> OutputSynapses
        {
            get
            {
                return Neuron.SynapsesOut;
            }
        }*/
    }
}
