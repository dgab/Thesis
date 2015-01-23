﻿using NeuralNet;
using NeuralNet.Neurons;
using NeuralNet.Training;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleNeuralNets
{
    class Program
    {
        static void Main(string[] args)
        {
            BackpropNetwork bpn = new BackpropNetwork(0.8, 0.1);
            bpn.Initialize(8, 15, 2);

            TrainingSet ts = new TrainingSet(bpn.Layers.InputLayer, bpn.Layers.OutputLayer);
            ts.Add(new TrainingSample(new List<double>() { 1, 0, 1, 0, 1, 0, 1, 0 }, new List<double> { 0.4, 0.9 }));
            ts.Add(new TrainingSample(new List<double>() { 1, 1, 1, 1, 1, 1, 1, 1 }, new List<double> { 0.2, 0.3 }));
            ts.Add(new TrainingSample(new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0 }, new List<double> { 0.3, 0.5 }));
            bpn.TrainingEpochEvent += bpn_TrainingEpochEvent;
            bpn.Train(ts, 10000, 0.0001);

            /*double error = 1;
            do
            {
                error = bpn.Train(ts);
                Console.WriteLine(error);
            } while (error > 0.0001);
            */
            while (true)
            {
                List<string> s = Console.ReadLine().Split(' ').ToList();
                List<double> inputs = new List<double>();
                foreach (string item in s)
                {
                    inputs.Add(Convert.ToDouble(item));
                }

                bpn.Run(inputs);

                string asd = "";

                foreach (Neuron item in bpn.Layers.OutputLayer.Neurons)
                {
                    asd += item.Output.ToString() + " ";
                }
                Console.WriteLine(asd);
            }
        }

        static void bpn_TrainingEpochEvent(object sender, TrainingEpochEventArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine(string.Format("Current iteration:{0}  || Error:{1}", e.CurrentIteration, e.Error));
        }

        /*NetworkVariables.Eta = 0.9;
NetworkVariables.Momentum = 0.04;
InputLayer il = new InputLayer();
il.AddNeurons(1);

HiddenLayer hl = new HiddenLayer(il);
hl.AddNeurons(2);

OutputLayer ol = new OutputLayer(hl);
ol.AddNeurons(1);

il.InitializeWeights();
hl.InitializeWeights();
ol.InitializeWeights();

//Console.ReadKey();
int counter = 0;
double error = 1;
while (counter <= 10000 && error > 0.0001)
{
    il.Neurons[1].Input = 0.2;
    //il.Neurons[2].Input = 0.7;

    il.CalculateOutputs();
    hl.CalculateOutputs();
    ol.CalculateOutputs();

    error = Math.Pow(0.7 - ol.Neurons[0].Output, 2);

    //if (counter % 100 == 0)
    //{
        Console.WriteLine(error);
    //}
    counter++;

    if (error < 0.0001)
    {
        break;
    }

    ol.CalculateGradients(new List<double>() { 0.7 });
    hl.CalculateGradients();

    il.UpdateWeights();
    hl.UpdateWeights();
    ol.UpdateWeights();
}

if (counter <= 10000)
{
    Console.WriteLine("Trained.");
}
else
{
    Console.WriteLine("Not trained.");
}

string ils = Serialization.Serialize<InputLayer>(il);
string hls = Serialization.Serialize<HiddenLayer>(hl);
string ols = Serialization.Serialize<OutputLayer>(ol);

bool a = true;

while (a)
{
    double input = Convert.ToDouble(Console.ReadLine());
    a = input == 100 ? false : true;
    il.Neurons[1].Input = input;

    il.CalculateOutputs();
    hl.CalculateOutputs();
    ol.CalculateOutputs();

    Console.WriteLine(ol.Neurons[0].Output);

    string sil = Serialization.Serialize<InputLayer>(il);
    string shl = Serialization.Serialize<HiddenLayer>(hl);
    string sol = Serialization.Serialize<OutputLayer>(ol);
}*/
    }
}
