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
    }
}
