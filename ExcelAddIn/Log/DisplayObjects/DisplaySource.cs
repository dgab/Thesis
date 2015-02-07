using NeuralNet;
using NeuralNet.Layers;
using NeuralNet.Neurons;
using NeuralNet.Others;
using System.Collections.Generic;
using System.Linq;

namespace ExcelAddIn.Log
{
    public class DisplaySource
    {
        public IList<DisplayNeuron> Neurons { get; set; }

        public IList<DisplaySynapse> Synapses { get; set; }

        private BackpropNetwork backpropNetwork
        {
            get
            {
                return Network.Default;
            }
        }
        public DisplaySource()
        {
            this.Neurons = new List<DisplayNeuron>();
            this.Synapses = new List<DisplaySynapse>();
        }

        public void GetDisplayObjects()
        {
            backpropNetwork.Initialize(6, 6, 6);
            double x = 50;
            double y = 50;

            foreach (Layer l in backpropNetwork.Layers)
            {
                foreach (BaseNeuron n in l.Neurons)
                {
                    this.Neurons.Add(new DisplayNeuron() { X = x, Y = y, Neuron = n });
                    y += 50;
                }
                y = 50;
                x += 50;
            }

            foreach (DisplayNeuron n in this.Neurons)
            {
                foreach (Synapse s in n.Neuron.SynapsesOut)
                {
                    DisplaySynapse ds = new DisplaySynapse();
                    ds.Start = n;
                    ds.End = this.Neurons.First(c => c.Neuron == s.OutputNeuron);
                    ds.Synapse = s;
                    this.Synapses.Add(ds);
                }
            }
            //this.Synapses.Add(new DisplaySynapse() { Start = Neurons[0], End = Neurons[1] });
        }
    }
}
