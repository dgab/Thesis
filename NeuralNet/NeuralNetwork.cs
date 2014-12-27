using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet.Layers;

namespace NeuralNet
{
    public class NeuralNetwork
    {
        private InputLayer InputLayer;
        private List<HiddenLayer> HiddenLayers;
        private OutputLayer OutputLayer;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:NeuralNetwork"/> class.
        /// </summary>
        public NeuralNetwork(InputLayer input, List<HiddenLayer> hidden, OutputLayer output)
        {
            //ValidateArguments(input, hidden, output);

            this.InputLayer = input;
            this.HiddenLayers = hidden;
            this.OutputLayer = output;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NeuralNetwork"/> class.
        /// </summary>
        public NeuralNetwork(InputLayer input, HiddenLayer hidden, OutputLayer output)
            : this(input, new List<HiddenLayer>() {hidden}, output)
        {

        }

        /*private void ValidateArguments(InputLayer input, List<HiddenLayer> hidden, OutputLayer output)
        {
            if (input.Neurons.Count == 0)
            {
                throw new ArgumentException("There are no neurons defined in the InputLayer");
            }
            if (hidden.Count == 0)
            {
                throw new ArgumentException("No hidden layer was supplied!");
            }
            foreach (HiddenLayer hlay in hidden)
            {
                if (hlay.Neurons.Count == 0)
                {
                    throw new ArgumentException(string.Format("There are no neurons defined in the {0}. HiddenLayer", hidden.IndexOf(hlay) + 1));
                }
            }
            if (output.Neurons.Count == 0)
            {
                throw new ArgumentException("There are no neurons defined in the OutputLayer");
            }
        }*/
    }
}
