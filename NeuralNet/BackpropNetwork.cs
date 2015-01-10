using NeuralNet.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace NeuralNet
{
    [XmlRoot("BackpropNetwork")]
    public class BackpropNetwork
    {
        [XmlElement("Eta")]
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

        [XmlElement("Momentum")]
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

        [XmlArray("Layers")]
        [XmlArrayItem("Layer")]
        public List<Layer> Layers { get; set; }

        public InputLayer InputLayer
        {
            get
            {
                return (InputLayer)Layers.First();
            }
        }

        public OutputLayer OutputLayer
        {
            get
            {
                return (OutputLayer)Layers.Last();
            }
        }

        public List<HiddenLayer> HiddenLayers
        {
            get
            {
                return Layers.OfType<HiddenLayer>().ToList();
            }
        }

        /// <summary>
        /// Only for serialization.
        /// </summary>
        public BackpropNetwork()
        {

        }

        public BackpropNetwork(params int[] sizes)
        {
            if (sizes.Length < 2)
            {
                throw new ArgumentException("At least two layers must be defined!");
            }
            else
            {
                Layers = new List<Layer>();

                InputLayer il = new InputLayer();
                il.AddNeurons(sizes.First());

                Layers.Add(il);

                for (int i = 1; i < sizes.Length - 1; i++)
                {
                    HiddenLayer hl = new HiddenLayer(Layers.Last());
                    hl.AddNeurons(sizes[i]);

                    Layers.Add(hl);
                }

                OutputLayer ol = new OutputLayer(Layers.Last());
                ol.AddNeurons(sizes.Last());

                Layers.Add(ol);
            }

        }

        public void InitializeWeights()
        {
            foreach (Layer l in this.Layers)
            {
                l.InitializeWeights();
            }
        }

        public double Train(TrainingSet ts)
        {
            //TODO: validate ts by the network
            this.InputLayer.ApplyTrainingSet(ts);
            
            foreach (Layer l in this.Layers)
	        {
		        //l.InitializeWeights();
                l.CalculateOutputs();
	        }

            this.OutputLayer.ApplyTrainingSet(ts);

            this.OutputLayer.CalculateGradients();

            Layer nextlayer = this.OutputLayer;

            for (int i = HiddenLayers.Count - 1; i <= 0; i++)
            {
                HiddenLayers[i].CalculateGradients(nextlayer);
                nextlayer = HiddenLayers[i];
            }

            foreach (Layer l in this.Layers)
            {
                l.UpdateWeights();
            }

            return this.OutputLayer.CalculateError();
        }

        public double Process(double input)
        {
            this.InputLayer.Neurons[0].Input = input;

            foreach (Layer l in this.Layers)
            {
                //l.InitializeWeights();
                l.CalculateOutputs();
            }

            return this.OutputLayer.Neurons[0].Output;
        }
    }
}
