using ExcelAddIn.Log;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ExcelAddIn
{
    class LogViewModel : ViewModel
    {
        private ObservableCollection<DisplayNeuron> neurons;
        public ObservableCollection<DisplayNeuron> Neurons
        {
            get
            {
                return this.neurons ?? (neurons = new ObservableCollection<DisplayNeuron>());
            }
        }

        private ObservableCollection<DisplaySynapse> synapses;
        public ObservableCollection<DisplaySynapse> Synapses
        {
            get
            {
                return this.synapses ?? (synapses = new ObservableCollection<DisplaySynapse>());
            }
        }

        private ICommand runCommand;
        public ICommand RunCommand
        {
            get
            {
                if (runCommand == null)
                {
                    runCommand = new CommandHandler(() => Run(), true);
                }
                return runCommand;
            }
        }

        private DisplayObject _selectedObject;
        public DisplayObject SelectedObject
        {
            get
            {
                return _selectedObject;
            }
            set
            {
                //Nodes.ToList().ForEach(x => x.IsHighlighted = false);

                _selectedObject = value;
                OnPropertyChanged("SelectedObject");

                //DeleteCommand.IsEnabled = value != null;

                //var connector = value as Connector;
                //if (connector != null)
                //{
                //    if (connector.Start != null)
                //        connector.Start.IsHighlighted = true;

                //    if (connector.End != null)
                //        connector.End.IsHighlighted = true;
                //}

            }
        }

        public LogViewModel()
        {
            DisplaySource ds = new DisplaySource();
            ds.GetDisplayObjects();
            this.neurons = new ObservableCollection<DisplayNeuron>(ds.Neurons);
            this.synapses = new ObservableCollection<DisplaySynapse>(ds.Synapses);

            this.SelectedObject = this.Neurons.Count != 0 ? this.Neurons[0] : null;
            Network.OnNetworkChanged += Network_OnNetworkChanged;
        }

        void Network_OnNetworkChanged(object sender, System.EventArgs e)
        {
            DisplaySource ds = new DisplaySource();
            ds.GetDisplayObjects();
            /*this.neurons = new ObservableCollection<DisplayNeuron>(ds.Neurons);
            this.synapses = new ObservableCollection<DisplaySynapse>(ds.Synapses);*/
            this.Neurons.Clear();
            foreach (var item in ds.Neurons)
            {
                this.Neurons.Add(item);
            }

            this.Synapses.Clear();
            foreach (var item in ds.Synapses)
            {
                this.Synapses.Add(item);
            }

            if (this.neurons.Count != 0)
            {
                SelectedObject = this.neurons[0];
            }
        }

        private void Run()
        {
            Network.Default.Run();
        }
        #region Scrolling support

        private double _areaHeight = 500;
        public double AreaHeight
        {
            get { return _areaHeight; }
            set
            {
                _areaHeight = value;
                OnPropertyChanged("AreaHeight");
            }
        }

        private double _areaWidth = 500;
        public double AreaWidth
        {
            get { return _areaWidth; }
            set
            {
                _areaWidth = value;
                OnPropertyChanged("AreaWidth");
            }
        }

        #endregion
    }
}
