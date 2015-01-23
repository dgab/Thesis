using NeuralNet.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet.Layers
{
    public class LayerCollection : IList<Layer>
    {
        private readonly IList<Layer> layers = new List<Layer>();

        public InputLayer InputLayer
        {
        }

        public OutputLayer OutputLayer
        {
            get
            {
                return layers.Last().As<OutputLayer>();
            }
        }
        #region IEnumerable
        public IEnumerator<Layer> GetEnumerator()
        {
            return this.layers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection
        public void Add(Layer item)
        {
            this.layers.Add(item);
        }

        public void Clear()
        {
            this.layers.Clear();
        }

        public bool Contains(Layer item)
        {
            return this.layers.Contains(item);
        }

        public void CopyTo(Layer[] array, int arrayIndex)
        {
            this.layers.CopyTo(array, arrayIndex);
        }

        public bool Remove(Layer item)
        {
            return this.Remove(item);
        }

        public int Count
        {
            get { return this.layers.Count; }
        }

        public bool IsReadOnly
        {
            get { return this.layers.IsReadOnly; }
        }
        #endregion

        #region IList<T>
        public int IndexOf(Layer item)
        {
            return this.layers.IndexOf(item);
        }

        public void Insert(int index, Layer item)
        {
            this.layers.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.layers.RemoveAt(index);
        }

        public Layer this[int index]
        {
            get
            {
                return this.layers[index];
            }
            set
            {
                this.layers[index] = value;
            }
        }
        #endregion

        #region My stuff

        public void Add(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Invalid size of the layer. Size must be 1 or greater.");
            }

            switch (layers.Count)
            {
                case 0:
                    AddInputLayer(size);
                    break;
                case 1:
                    AddOutputLayer(size);
                    break;
                default:
                    AddHiddenLayer(size);
                    break;
            }
        }

        private void AddInputLayer(int size)
        {
            InputLayer il = new InputLayer();
            il.AddNeurons(size);
            this.layers.Add(il);
        }

        private void AddOutputLayer(int size)
        {
            OutputLayer ol = new OutputLayer(this.layers.Last());
            ol.AddNeurons(size);
            this.layers.Add(ol);
        }

        private void AddHiddenLayer(int size)
        {
            OutputLayer tmp = (OutputLayer)this.layers.Last();
            HiddenLayer hl = (HiddenLayer)tmp;
            this.layers.RemoveAt(this.layers.Count - 1);
            this.layers.Add(hl);
            this.AddOutputLayer(size);
        }
        #endregion
    }
}
