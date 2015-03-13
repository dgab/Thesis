using NeuralNet.Layers;
using NeuralNet.Others;
using NeuralNet.Training;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet
{
    public delegate void TrainingEpochDelegate(object sender, TrainingEpochEventArgs e);
    public class BackpropNetwork
    {
        public event TrainingEpochDelegate TrainingEpochEvent;

        public void OnTrainingEpoch(object sender, TrainingEpochEventArgs e)
        {
            if (this.TrainingEpochEvent != null)
            {
                this.TrainingEpochEvent(sender, e);
            }
        }
        public LayerCollection Layers { get; set; }

        public TrainingSet TrainingSet { get; set; }

        private bool initialized = false;
        public bool Initialized
        {
            get
            {
                return this.initialized;
            }
        }
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

        /// <summary>
        /// Does on training iteration.
        /// </summary>
        /// <param name="trainingSet">The targets and inputs.</param>
        /// <returns></returns>
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

                return error / 2;/// this.Layers.OutputLayer.Neurons.Count;
            }
            else
            {
                throw new InvalidOperationException("The network must first be initialized!");
            }
        }

        public void Train(TrainingSet ts, int iterations, double errorLevel)
        {
            double error = 1;
            int currentIteration = 0;

            while (error > errorLevel && iterations > currentIteration)
            {
                error = this.Train(ts);
                currentIteration++;
                this.OnTrainingEpoch(this, new TrainingEpochEventArgs(error, currentIteration));
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

        public void Run()
        {
            foreach (Layer l in this.Layers)
            {
                l.CalculateOutputs();
            }
        }
    }
}
