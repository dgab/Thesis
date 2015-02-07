
using NeuralNet.Neurons;
using System;
using System.Windows.Media;
namespace ExcelAddIn.Log
{
    public class DisplayNeuron : DisplayObject
    {
        private double x;
        public override double X
        {
            get { return x; }
            set
            {
                x = (Math.Round(value / 50.0)) * 50;
                OnPropertyChanged("X");
            }
        }

        private double y;
        public override double Y
        {
            get { return y; }
            set
            {
                y = (Math.Round(value / 50.0)) * 50;
                OnPropertyChanged("Y");
            }
        }

        private bool isHighlighted { get; set; }
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

        public BaseNeuron Neuron { get; set; }

        private Color color = Colors.Blue;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
    }
}
