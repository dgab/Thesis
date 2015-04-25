using NeuralNet.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet.Layers
{
    /// <summary>
    /// Egy, a rétegeket tárolni és menedzselni tudó objektum.
    /// </summary>
    public class LayerCollection : IList<Layer>
    {
        private readonly IList<Layer> layers = new List<Layer>();

        /// <summary>
        /// A bementi réteg.
        /// </summary>
        public InputLayer InputLayer
        {
            get
            {
                return layers.First().As<InputLayer>();
            }
        }

        /// <summary>
        /// A kimeneti réteg.
        /// </summary>
        public OutputLayer OutputLayer
        {
            get
            {
                return layers.Last().As<OutputLayer>();
            }
        }
        #region IEnumerable
        /// <summary>
        /// Az IEnumerable interfacet metódusának megvalósítása.
        /// </summary>
        /// <returns>IEnumerator<Layer></returns>
        public IEnumerator<Layer> GetEnumerator()
        {
            return this.layers.GetEnumerator();
        }

        /// <summary>
        /// Az IEnumerable interfacet metódusának megvalósítása.
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection
        /// <summary>
        /// Réteg hozzáadására alkalmas.
        /// </summary>
        /// <param name="item">A réteg, amit hozzá szeretnénk adni.</param>
        public void Add(Layer item)
        {
            this.layers.Add(item);
        }

        /// <summary>
        /// Az összes réteget törli a gyűjteményből.
        /// </summary>
        public void Clear()
        {
            this.layers.Clear();
        }

        /// <summary>
        /// Meghatározza, hogy az adott réteg létezik-e a gyűjteményben.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(Layer item)
        {
            return this.layers.Contains(item);
        }

        /// <summary>
        /// A rétegek másolására alkalmas.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(Layer[] array, int arrayIndex)
        {
            this.layers.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Egy adott réteg törlését hajtja végre.
        /// </summary>
        /// <param name="item">Az adott réteg.</param>
        /// <returns>A törlés sikeressége.</returns>
        public bool Remove(Layer item)
        {
            return this.Remove(item);
        }

        /// <summary>
        /// A gyűjteményben lévő rétegek száma.
        /// </summary>
        public int Count
        {
            get { return this.layers.Count; }
        }

        /// <summary>
        /// Meghatározza, hogy a gyűjtemény módosítható-e.
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.layers.IsReadOnly; }
        }
        #endregion

        #region IList<T>
        /// <summary>
        /// Az adott réteg indexét adja vissza.
        /// </summary>
        /// <param name="item">Az adott réteg.</param>
        /// <returns>Az index.</returns>
        public int IndexOf(Layer item)
        {
            return this.layers.IndexOf(item);
        }

        /// <summary>
        /// Beszúr egy réteget a specifikált helyre.
        /// </summary>
        /// <param name="index">A specifikált hely.</param>
        /// <param name="item">Az adott réteg.</param>
        public void Insert(int index, Layer item)
        {
            this.layers.Insert(index, item);
        }

        /// <summary>
        /// Törli a réteget a meghatározott helyről.
        /// </summary>
        /// <param name="index">A réteg indexxe.</param>
        public void RemoveAt(int index)
        {
            this.layers.RemoveAt(index);
        }

        /// <summary>
        /// Visszaadja az adott réteget a specifikált indexen.
        /// </summary>
        /// <param name="index">Az index.</param>
        /// <returns>A réteg.</returns>
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

        /// <summary>
        /// Hozzáad egy adott méretű réteget.
        /// </summary>
        /// <param name="size">A réteg mérete.</param>
        /// <exception cref="ArgumentException">Kivételt dob, ha a méret 0 vagy annál kissebb.</exception>
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
