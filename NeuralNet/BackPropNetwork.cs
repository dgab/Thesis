using NeuralNet.Layers;
using NeuralNet.Others;
using NeuralNet.Training;
using System;
using System.Linq;

namespace NeuralNet
{
    public class BackPropNetwork
    {
        public LayerCollection Layers { get; set; }

        public double Eta
        {
            get
            {
                return NetworkVariables.Eta;
            }
            set
            {
                NetworkVariables.Eta = value;
            }
        }

        public double Momentum
        {
            get
            {
                return NetworkVariables.Momentum;
            }
            set
            {
                NetworkVariables.Momentum = value;
            }
        }

        public BackPropNetwork()
        {
            Layers = new LayerCollection();
        }

        public BackPropNetwork(double eta, double momentum)
            : this()
        {
            this.Eta = eta;
            this.Momentum = momentum;
        }

        public void Initialize(params int[] layerSizes)
        {
            if (layerSizes.Count() < 2)
            {
                throw new ArgumentException("There must be at least two layers.");
            }

            this.Layers.Clear();

            foreach (int size in layerSizes)
            {
                this.Layers.Add(size);
            }

            foreach (Layer l in this.Layers)
            {
                l.InitializeWeights();
            }
        }
    }
}
