using NeuralNet.Layers;
using NeuralNet.Others;
using NeuralNet.Training;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet
{
    public class BackpropNetwork
    {
        public LayerCollection Layers { get; set; }

        public TrainingSet TrainingSet { get; set; }

        private bool initialized = false;
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

        public BackpropNetwork()
        {
            Layers = new LayerCollection();
        }

        public BackpropNetwork(double eta, double momentum)
            : this()
        {
            this.Eta = eta;
            this.Momentum = momentum;
        }

        public void Initialize(params int[] layerSizes)
        {
            this.initialized = false;

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

            this.initialized = true;
        }

        public double Train(TrainingSet trainingSet)
        {
            if (this.initialized)
            {
                double error = 0;

                foreach (TrainingSample ts in trainingSet)
                {
                    this.Layers.InputLayer.AddInputs(ts.Inputs);

                    foreach (Layer l in this.Layers)
                    {
                        l.CalculateOutputs();
                    }

                    error += this.Layers.OutputLayer.CalculateGradients(ts.Targets);

                    foreach (Layer l in this.Layers)
                    {
                        l.UpdateWeights();
                    }
                }

                return error / this.Layers.OutputLayer.Neurons.Count;
            }
            else
            {
                throw new InvalidOperationException("The network must first be initialized!");
            }
        }

        public void Run(List<double> inputs)
        {
            this.Layers.InputLayer.AddInputs(inputs);

            foreach (Layer l in this.Layers)
            {
                l.CalculateOutputs();
            }
        }
    }
}
