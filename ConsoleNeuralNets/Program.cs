using NeuralNet.Layers;
using NeuralNet.Others;
using NeuralNet.Serialization;
using System;
using System.Collections.Generic;

namespace ConsoleNeuralNets
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkVariables.Eta = 0.9;
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
            }

        }
    }
}
