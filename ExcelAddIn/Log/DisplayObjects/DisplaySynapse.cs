using NeuralNet.Others;
using System.ComponentModel;

namespace ExcelAddIn.Log
{
    [DisplayName("Line")]
    [Description("This element represents a weight in the network.")]
    public class DisplaySynapse : DisplayObject
    {
        [Browsable(false)]
        public override double X
        {
            get { return 0; }
            set { }
        }

        [Browsable(false)]
        public override double Y
        {
            get { return 0; }
            set { }
        }

        private Synapse synapse;

        [Browsable(false)]
        public Synapse Synapse
        {
            get
            {
                return synapse;
            }
            set
            {
                synapse = value;
                OnPropertyChanged("Synapse");
            }
        }

        [Browsable(false)]
        public double Weight
        {
            get
            {
                if (Synapse.Weight < 0.6)
                {
                    return 0.6;
                }
                if (Synapse.Weight > 2.5)
                {
                    return 2.5;
                }

                return Synapse.Weight;
            }
        }

        private DisplayNeuron start;

        [Browsable(false)]
        public DisplayNeuron Start
        {
            get { return start; }
            set
            {
                start = value;
                OnPropertyChanged("Start");
            }
        }

        private DisplayNeuron end;

        [Browsable(false)]
        public DisplayNeuron End
        {
            get { return end; }
            set
            {
                end = value;
                OnPropertyChanged("End");
            }
        }

        [Category("Display")]
        [DisplayName("StartX")]
        [Description("Gets the X coordinate of the starting point.")]
        public double StartX
        {
            get
            {
                return this.Start.X;
            }
        }

        [Category("Display")]
        [DisplayName("StartY")]
        [Description("Gets the Y coordinate of the starting point.")]
        public double StartY
        {
            get
            {
                return this.Start.Y;
            }
        }

        [Category("Display")]
        [DisplayName("EndX")]
        [Description("Gets the X coordinate of the end point.")]
        public double EndX
        {
            get
            {
                return this.End.X;
            }
        }

        [Category("Display")]
        [DisplayName("EndY")]
        [Description("Gets the X coordinate of the end point.")]
        public double EndY
        {
            get
            {
                return this.End.Y;
            }
        }

        [Category("Synapse")]
        [DisplayName("Weight")]
        [Description("Gets the actual Weight of the synapse.")]
        public string ActualWeight
        {
            get
            {
                return this.Synapse.Weight.ToString("N3");
            }
        }

        [Category("Synapse")]
        [DisplayName("Delta")]
        [Description("Gets the Delta of the synapse.")]
        public string Delta
        {
            get
            {
                return this.Synapse.Delta.ToString("N3");
            }
        }

        [Category("Synapse")]
        [DisplayName("Previous Delta")]
        [Description("Gets the Previous Delta of the synapse.")]
        public string PreviousDelta
        {
            get
            {
                return this.Synapse.PreviousDelta.ToString("N3");
            }
        }
    }
}
