using NeuralNet;
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
            BackpropNetwork bpn = new BackpropNetwork(0.5, 0.04);
            bpn.Initialize(7, 7, 1);

            TrainingSet ts = new TrainingSet(bpn.Layers.InputLayer, bpn.Layers.OutputLayer);
            /*ts.Add(new TrainingSample(new List<double>() { 1, 0, 1, 0, 1, 0, 1 }, new List<double> { 0.1, 0.2, 0.3, 0.4}));
            ts.Add(new TrainingSample(new List<double>() { 1, 1, 1, 1, 1, 1, 1 }, new List<double> { 0.2, 0.3, 0.7, 0.8}));
            ts.Add(new TrainingSample(new List<double>() { 0, 0, 0, 0, 0, 0, 0 }, new List<double> { 0.3, 0.5, 0.6, 0.2 }));*/

            ts.Add(new TrainingSample(new List<double>() { 1, 1, 1, 1, 1, 1, 0 }, new List<double> { 0.05 }));
            ts.Add(new TrainingSample(new List<double>() { 0, 1, 1, 0, 0, 0, 0 }, new List<double> { 0.15 }));
            ts.Add(new TrainingSample(new List<double>() { 1, 1, 0, 1, 1, 0, 1 }, new List<double> { 0.25 }));
            ts.Add(new TrainingSample(new List<double>() { 1, 1, 1, 1, 0, 0, 1 }, new List<double> { 0.35 }));
            ts.Add(new TrainingSample(new List<double>() { 0, 1, 1, 0, 0, 1, 1 }, new List<double> { 0.45 }));
            ts.Add(new TrainingSample(new List<double>() { 1, 0, 1, 1, 0, 1, 1 }, new List<double> { 0.55 }));
            ts.Add(new TrainingSample(new List<double>() { 1, 0, 1, 1, 1, 1, 1 }, new List<double> { 0.65 }));
            ts.Add(new TrainingSample(new List<double>() { 1, 1, 1, 0, 0, 0, 0 }, new List<double> { 0.75 }));
            ts.Add(new TrainingSample(new List<double>() { 1, 1, 1, 1, 1, 1, 1 }, new List<double> { 0.85 }));
            ts.Add(new TrainingSample(new List<double>() { 1, 1, 1, 1, 0, 1, 1 }, new List<double> { 0.95 }));
            bpn.TrainingEpochEvent += bpn_TrainingEpochEvent;
            bpn.Train(ts, int.MaxValue, 0.001);

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
    }
}
