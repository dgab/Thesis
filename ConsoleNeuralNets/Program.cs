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
            BackpropNetwork bpn = new BackpropNetwork(1,1);
            bpn.InitializeWeights();

            TrainingSet ts = new TrainingSet();
            ts.AddInputs(0.5);
            ts.AddTargets(0.7);

            int counter = 0;
            double error = 1;
            while (counter <= 10000 && error > 0.0001)
            {
                error = bpn.Train(ts);
                counter++;
                if (counter % 100 == 0)
                {
                    Console.WriteLine(error);
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Trained");

            while (true)
            {
                Console.WriteLine(bpn.Process(Convert.ToDouble(Console.ReadLine())));
            }
            Console.ReadKey();
        }
    }
}
