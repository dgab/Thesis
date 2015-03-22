using NeuralNet.Layers;
using NeuralNet.Neurons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet.Training
{
    public class TrainingSet : IList<TrainingSample>
    {

        private readonly IList<TrainingSample> trainingSamples = new List<TrainingSample>();

        #region IEnumerable
        public IEnumerator<TrainingSample> GetEnumerator()
        {
            return this.trainingSamples.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection
        public void Add(TrainingSample item)
        {
            if (this.Validate(item) == false)
            {
                throw new ArgumentException("The input or target size of the given training sample did not match with the count of the neurons on the corresponing layer.");
            }
            else
            {
                this.trainingSamples.Add(item);
            }
        }

        public void Clear()
        {
            this.trainingSamples.Clear();
        }

        public bool Contains(TrainingSample item)
        {
            return this.trainingSamples.Contains(item);
        }

        public void CopyTo(TrainingSample[] array, int arrayIndex)
        {
            this.trainingSamples.CopyTo(array, arrayIndex);
        }

        public bool Remove(TrainingSample item)
        {
            return this.Remove(item);
        }

        public int Count
        {
            get { return this.trainingSamples.Count; }
        }

        public bool IsReadOnly
        {
            get { return this.trainingSamples.IsReadOnly; }
        }
        #endregion

        #region IList<T>
        public int IndexOf(TrainingSample item)
        {
            return this.trainingSamples.IndexOf(item);
        }

        public void Insert(int index, TrainingSample item)
        {
            this.trainingSamples.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.trainingSamples.RemoveAt(index);
        }

        public TrainingSample this[int index]
        {
            get
            {
                return this.trainingSamples[index];
            }
            set
            {
                this.trainingSamples[index] = value;
            }
        }
        #endregion

        #region MyStuff

        public TrainingSet(Layer inputLayer, Layer outputLayer)
        {
            this.inputSize = inputLayer.Neurons.OfType<Neuron>().Count();
            this.targetSize = outputLayer.Neurons.OfType<Neuron>().Count();
        }

        public TrainingSet(int inputSize, int outputSize)
        {
            this.inputSize = inputSize;
            this.targetSize = outputSize;
        }

        private int inputSize { get; set; }

        private int targetSize { get; set; }

        private bool Validate(TrainingSample trainingSample)
        {
            bool result = true;

            if (trainingSample.Inputs.Count != inputSize)
            {
                result = false;
            }
            if (trainingSample.Targets.Count != targetSize)
            {
                result = false;
            }

            return result;
        }
        #endregion
    }
}
