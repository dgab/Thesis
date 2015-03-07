using NeuralNet.Functions;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExcelAddIn.Init
{
    class InitViewModel : ViewModel
    {
        public ObservableCollection<LayerView> Layers { get; set; }

        public Array Functions { get; set; }

        private bool removeEnabled = false;
        public bool RemoveEnabled
        {
            get
            {
                return this.removeEnabled;
            }
            set
            {
                this.removeEnabled = value;
                OnPropertyChanged("RemoveEnabled");
            }
        }
        public RelayCommand Add { get; set; }

        public RelayCommand Remove { get; set; }

        public RelayCommand Init { get; set; }
        public InitViewModel()
        {
            this.Layers = new ObservableCollection<LayerView>();
            Layers.Add(new LayerView("Input", 1, TransferFunctions.Identity));
            Layers.Add(new LayerView("Output", 1, TransferFunctions.Sigmoid));

            Functions = Enum.GetValues(typeof(TransferFunctions));

            Add = new RelayCommand(AddLayer);
            Remove = new RelayCommand(RemoveLayer);
            Init = new RelayCommand(Initialize);
        }

        public void AddLayer()
        {
            LayerView l = new LayerView("Hidden", 1, TransferFunctions.Sigmoid);
            this.Layers.Insert(this.Layers.Count - 1, l);
            this.RemoveEnabled = this.Layers.Count > 2;
        }

        public void RemoveLayer()
        {
            this.Layers.RemoveAt(this.Layers.Count - 2);
            this.RemoveEnabled = this.Layers.Count > 2;
        }

        public void Initialize()
        {
            int[] sizes = Layers.Select(x => x.NumberOfNeurons).ToArray();
            Network.Initialize(sizes);
        }
    }
}
