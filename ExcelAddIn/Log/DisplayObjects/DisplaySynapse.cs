
using NeuralNet.Others;
namespace ExcelAddIn.Log
{
    public class DisplaySynapse : DisplayObject
    {
        public override double X
        {
            get { return 0; }
            set { }
        }

        public override double Y
        {
            get { return 0; }
            set { }
        }

        private Synapse synapse;
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

        public double Weight
        {
            get
            {
                if (Synapse.Weight < 0.3)
                {
                    return 0.3;
                }
                if (Synapse.Weight > 2.5)
                {
                    return 2.5;
                }

                return Synapse.Weight;
            }
        }

        private DisplayNeuron start;
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
        public DisplayNeuron End
        {
            get { return end; }
            set
            {
                end = value;
                OnPropertyChanged("End");
            }
        }
    }
}
