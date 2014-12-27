using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNet.Layers;
using NeuralNet;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class NetworkTest
    {
        [TestMethod]
        public void NetworkTest1()
        {
            InputLayer inputLayer = new InputLayer();

            Neuron n1 = new Neuron(inputLayer);
            n1.Input = 1;

            Neuron n2 = new Neuron(inputLayer);
            n2.Input = 2;

            Neuron n3 = new Neuron(inputLayer);
            n3.Input = 3;

            inputLayer.Neurons.AddRange(new List<Neuron>() { n1, n2, n3 });

            inputLayer.CalculateOutputs();

            HiddenLayer hiddenLayer = new HiddenLayer(inputLayer);
            hiddenLayer.Neurons.Add(new Neuron(hiddenLayer));
            hiddenLayer.Neurons.Add(new Neuron(hiddenLayer));
            hiddenLayer.Neurons.Add(new Neuron(hiddenLayer));
            hiddenLayer.Neurons.Add(new Neuron(hiddenLayer));

            hiddenLayer.InitializeWeights();
            hiddenLayer.CalculateOutputs();

            OutputLayer outputLayer = new OutputLayer(hiddenLayer);
            outputLayer.Neurons.Add(new Neuron(outputLayer));
            outputLayer.Neurons.Add(new Neuron(outputLayer));

            outputLayer.InitializeWeights();
            outputLayer.CalculateOutputs();
        }
    }
}
