using NeuralNet.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Layers
{
    public class OutputLayer : Layer, ILayer
    {
        public Layer PreviousLayer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:OutputLayer"/> class.
        /// </summary>
        public OutputLayer(Layer previousLayer)
            :base()
        {
            this.PreviousLayer = previousLayer;
        }

        public void InitializeWeights()
        {
            foreach (Neuron n in this.Neurons)
            {
                n.InitializeWeights(PreviousLayer);
            }
        }

        public override void CalculateOutputs()
        {
            foreach (Neuron n in Neurons)
            {
                n.CalculateOutput(PreviousLayer);
            }
        }
    }
}
