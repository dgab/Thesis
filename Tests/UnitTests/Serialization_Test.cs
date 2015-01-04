using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNet.Neurons;
using NeuralNet.Serialization;
using NeuralNet.Layers;
using NeuralNet;

namespace Tests.UnitTests
{
    [TestClass]
    public class Serialization_Test
    {
        [TestMethod]
        public void Neuron_Serialization()
        {
            Neuron n1 = new Neuron();
            n1.Layer = new InputLayer();
            n1.Input = 1;
            n1.CalculateOutput();

            Neuron n2 = new Neuron();
            n2.Layer = new HiddenLayer();

            Synapse w = new Synapse(n1, n2);
            w.Weight = 0.75;
            w.Weight = 1;

            n2.Weights.Add(w);
            n2.CalculateOutput();

            try
            {
                string s = Serializer.Serialize<Neuron>(n2);
            }
            catch (Exception e)
            {
                Assert.Fail("Neuron Serialization failed.");
            }
        }

        [TestMethod]
        public void InputLayer_Serialization()
        {
            InputLayer il = new InputLayer();
            il.AddNeurons(3);
            il.CalculateOutputs();

            try
            {
                string s = Serializer.Serialize<InputLayer>(il);
            }
            catch (Exception e)
            {
                
                Assert.Fail("InputLayer Serialiazation failed.");
            }
        }

        [TestMethod]
        public void HiddenLayer_Serialization()
        {
            InputLayer il = new InputLayer();
            il.AddNeurons(3);
            il.CalculateOutputs();

            HiddenLayer hl = new HiddenLayer(il);
            hl.AddNeurons(4);
            hl.InitializeWeights();
            hl.CalculateOutputs();

            try
            {
                string s = Serializer.Serialize<HiddenLayer>(hl);
            }
            catch (Exception e)
            {

                Assert.Fail("HiddenLayer Serialiazation failed.");
            }
        }

        [TestMethod]
        public void OutputLayer_Serialization()
        {
            InputLayer il = new InputLayer();
            il.AddNeurons(3);
            il.CalculateOutputs();

            HiddenLayer hl = new HiddenLayer(il);
            hl.AddNeurons(4);
            hl.InitializeWeights();
            hl.CalculateOutputs();

            OutputLayer ol = new OutputLayer(hl);
            ol.AddNeurons(2);
            ol.InitializeWeights();
            ol.CalculateOutputs();

            try
            {
                string s = Serializer.Serialize<OutputLayer>(ol);
            }
            catch (Exception e)
            {

                Assert.Fail("OutputLayer Serialiazation failed.");
            }
        }

        [TestMethod]
        public void Network_Serialization()
        {
            BackpropNetwork bpn = new BackpropNetwork(3,4,2);

            TrainingSet ts = new TrainingSet();
            ts.AddInputs(2, 3, 1);
            ts.AddTargets(0.8,-0.7);

            bpn.Train(ts);

            string s = Serializer.Serialize<BackpropNetwork>(bpn);
        }
    }
}
