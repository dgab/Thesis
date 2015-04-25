using NeuralNet.Layers;
using NeuralNet.Others;
using NeuralNet.Training;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet
{
    public delegate void TrainingEpochDelegate(object sender, TrainingEpochEventArgs e);

    /// <summary>
    /// Represent a neural network, that uses backpropagation for learning.
    /// </summary>
    public class BackpropNetwork
    {
        /// <summary>
        /// An event that is raised after each learning iteration.
        /// </summary>
        public event TrainingEpochDelegate TrainingEpochEvent;

        /// <summary>
        /// Raises the TrainingEpochEvent.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public void OnTrainingEpoch(object sender, TrainingEpochEventArgs e)
        {
            if (this.TrainingEpochEvent != null)
            {
                this.TrainingEpochEvent(sender, e);
            }
        }

        /// <summary>
        /// Gets or sets the Layers property.
        /// </summary>
        public LayerCollection Layers { get; set; }

        /// <summary>
        /// Gets or sets the TrainingSet property.
        /// </summary>
        public TrainingSet TrainingSet { get; set; }

        private bool initialized = false;

        /// <summary>
        /// Gets whether or not the network is in an initialized state.
        /// </summary>
        public bool Initialized
        {
            get
            {
                return this.initialized;
            }
        }

        /// <summary>
        /// Gets or sets the learning rate. Helps the network to learn faster.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the momentum. Helps to lower the chance of finding a local minima.
        /// </summary>
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

        private bool stopTraining = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackpropNetwork"/> class.
        /// </summary>
        public BackpropNetwork()
        {
            Layers = new LayerCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackpropNetwork"/> class.
        /// </summary>
        /// <param name="eta">Sets the value of the Eta property.</param>
        /// <param name="momentum">Sets the value of the Momentum property.</param>
        public BackpropNetwork(double eta, double momentum)
            : this()
        {
            this.Eta = eta;
            this.Momentum = momentum;
        }

        /// <summary>
        /// Initializes the network and sets the Initialized propety to true.
        /// </summary>
        /// <param name="layerSizes">An params array, that should contain only positive integers.</param>
        /// <exception cref="ArgumentException">Thrown when less than 2 integers were given.</exception>
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
        /// Performs one training iteration.
        /// </summary>
        /// <param name="trainingSet">The TrainingSet that is necessary for the training process.</param>
        /// <returns>The level of the error.</returns>
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

        /// <summary>
        /// Performs training iterations until the number of iteration equals with the maximum number of training iteration or until the 
        /// error is equal or less than the maximum error.
        /// </summary>
        /// <param name="ts">The TrainingSet that is necessary for the training process.</param>
        /// <param name="iterations">The number of maximum iteration.</param>
        /// <param name="errorLevel">The maximum error.</param>
        public void Train(TrainingSet ts, int iterations, double errorLevel)
        {
            double error = 1;
            int currentIteration = 0;
            this.stopTraining = false;

            while (error > errorLevel && iterations > currentIteration)
            {
                if (this.stopTraining)
                {
                    break;
                }

                error = this.Train(ts);
                currentIteration++;
                this.OnTrainingEpoch(this, new TrainingEpochEventArgs(error, currentIteration));
            }
        }

        /// <summary>
        /// Stops the training.
        /// </summary>
        public void StopTraining()
        {
            this.stopTraining = true;
        }


        /// <summary>
        /// Calculates the outputs for the current state of the network.
        /// </summary>
        public void Run()
        {
            foreach (Layer l in this.Layers)
            {
                l.CalculateOutputs();
            }
        }

        /// <summary>
        /// Calculates the outputs for the current state of the network.
        /// </summary>
        /// <param name="inputs">The input values.</param>
        public void Run(List<double> inputs)
        {
            this.Layers.InputLayer.AddInputs(inputs);

            this.Run();
        }


        /// <summary>
        /// Calculates the outputs for the current state of the network.
        /// </summary>
        /// <param name="ts">The input values.</param>
        /// <returns>The level of the error.</returns>
        public double Run(TrainingSample ts)
        {
            this.Run(ts.Inputs);
            return this.Layers.OutputLayer.CalculateError(ts.Targets);
        }
    }
}
