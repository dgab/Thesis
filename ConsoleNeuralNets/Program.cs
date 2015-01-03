using NeuralNet;
using NeuralNet.Functions;
using System;
using System.Collections.Generic;

namespace ConsoleNeuralNets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] layerSizes = new int[] { 1,2,1};
            TransferFunctions[] tf = new TransferFunctions[] { TransferFunctions.Sigmoid, TransferFunctions.Sigmoid, TransferFunctions.Sigmoid };

            NeuralNetwork nn = new NeuralNetwork(layerSizes, tf);
            nn.Eta = 0.25;

            Random r = new Random();
            int counter = 0;
            double e = 1;

            double i = r.NextDouble();
            double t = i * i;
            List<double> inputs = new List<double>() { i };
            List<double> targets = new List<double>() { t };

            while (counter <= 100000 || e <= 0.01)
            {


                nn.Train(inputs, targets);

                counter++;

                e = Math.Pow((t - nn.OutputLayer.SimpleNeurons[0].Output),2) /2;
                if (counter % 100 == 0)
                {
                    //Console.WriteLine(string.Format("Input: {0} Target: {1} Output: {2}" , i, t, nn.OutputLayer.SimpleNeurons[0].Output)); 
                    Console.WriteLine(e + " " + t + " " + nn.OutputLayer.SimpleNeurons[0].Output);
                    System.Threading.Thread.Sleep(1000);
                }
            }

            Console.ReadKey();
        }
    }
}
