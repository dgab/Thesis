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

        public TargetLayer TargetLayer
        {
            get
            {
                return (TargetLayer)Layers.Last();
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

                TargetLayer tl = new TargetLayer(Layers.Last());
                tl.AddNeurons(sizes.Last());

                Layers.Add(tl);
            }

        }

        public double Train(TrainingSet ts)
        {
            //TODO: validate ts by the network
            InputLayer.ApplyTrainingSet(ts);
            TargetLayer.ApplyTrainingSet(ts);
            foreach (Layer l in this.Layers)
	        {
		        l.InitializeWeights();
                l.CalculateOutputs();
	        }
            return 1;
        }
    }
}
