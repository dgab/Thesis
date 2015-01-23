﻿using NeuralNet.Layers;

namespace NeuralNet.Neurons
{
    public class BiasNeuron : BaseNeuron
    {
        public BiasNeuron(Layer currentLayer)
            : base(currentLayer)
        {
            this.Input = 1;
            this.Output = 1;
        }

        protected override bool CanCalculateOutput()
        {
            return false;
        }
    }
}
