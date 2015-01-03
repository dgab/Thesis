using NeuralNet.Functions;
using NeuralNet.Layers;
using NeuralNet.Neurons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet
{
    /// <summary>
    /// Todo: do I really need to know which layer is hidden and which layer is output?
    /// </summary>
    public class NeuralNetwork
    {
        public InputLayer InputLayer { get; set; }

        public List<HiddenLayer> HiddenLayers { get; set; }

        public OutputLayer OutputLayer { get; set; }

        public double Eta { get; set; }

        public List<ILayer> ProcessingLayers
        {
            get
            {
                return new List<ILayer>(HiddenLayers) {OutputLayer};
            }
        }
        public NeuralNetwork(int[] layerSize, TransferFunctions[] functionType)
        {
            InitializeLayers(layerSize, functionType);
            this.Eta = 0.9;
        }

        private void InitializeLayers(int[] layerSize, TransferFunctions[] functionType)
        {
            if (layerSize.Length <= 1)
            {
                throw new ArgumentException("There were less than 2 LayerSize in the layerSize array.");
            }

            if (layerSize.Length != functionType.Length)
            {
                throw new ArgumentException("The length of the layerSize array must match the length of the functionType array.");
            }

            this.InputLayer = new InputLayer(layerSize.First());

            if (layerSize.Length == 2)
            {
                this.OutputLayer = new OutputLayer(this.InputLayer, layerSize[1]);
            }
            else if (layerSize.Length == 3)
            {
                this.HiddenLayers = new List<HiddenLayer>();
                HiddenLayer h = new HiddenLayer(this.InputLayer, layerSize[1]);
                this.HiddenLayers.Add(h);

                this.OutputLayer = new OutputLayer(this.HiddenLayers.First(), layerSize.Last());
            }
            else
            {
                this.HiddenLayers = new List<HiddenLayer>();
                HiddenLayer h = new HiddenLayer(this.InputLayer, layerSize[1]);
                this.HiddenLayers.Add(h);

                for (int i = 2; i < layerSize.Length - 1; i++)
                {
                    HiddenLayer hl = new HiddenLayer(this.HiddenLayers[i - 2], layerSize[i]);
                    this.HiddenLayers.Add(hl);
                }

                this.OutputLayer = new OutputLayer(this.HiddenLayers.Last(), layerSize.Last());
            }

            this.InputLayer.TransferFunction = functionType.First();
            this.OutputLayer.TransferFunction = functionType.Last();

            List<TransferFunctions> functions = functionType.ToList();
            functions.RemoveAt(0);
            functions.RemoveAt(functions.Count - 1);
            for (int i = 0; i < this.HiddenLayers.Count; i++)
            {
                this.HiddenLayers[i].TransferFunction = functionType[i];
            }
        }

        public void Train(List<double> input, List<double> targets)
        {
            ForwardPass(input);
            BackPropagate(targets);
            UpdateWeights();
        }

        private void ForwardPass(List<double> input)
        {
            if (this.InputLayer.SimpleNeurons.Count() != input.Count)
            {
                throw new ArgumentException("Invalid amount of input values.");
            }

            for (int i = 0; i < input.Count; i++)
            {
                this.InputLayer.SimpleNeurons[i].Input = input[i];
            }

            this.InputLayer.CalculateOutputs();

            foreach (HiddenLayer layer in HiddenLayers)
            {
                layer.InitializeWeights();
                layer.CalculateOutputs();
            }

            this.OutputLayer.InitializeWeights();
            this.OutputLayer.CalculateOutputs();
        }

        private void BackPropagate(List<double> targets)
        {

            this.OutputLayer.CalculateGradients(targets);
            Layer nextLayer = this.OutputLayer;

            for (int i = HiddenLayers.Count - 1; i >= 0; i--)
            {
                HiddenLayers[i].CalculateGradients(nextLayer);
                nextLayer = HiddenLayers[i];
            }
        }

        private void CalculateDeltas()
        {
            this.ProcessingLayers.ForEach(x=>x.CalculateDeltas(this.Eta));
        }

        private void UpdateWeights()
        {
            this.ProcessingLayers.ForEach(x => x.CalculateDeltas(this.Eta));
        }

    }
}
