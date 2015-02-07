using ExcelAddIn.Log;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ExcelAddIn
{
    public class LogViewModel : INotifyPropertyChanged
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
        public LogViewModel()
        {
            DisplaySource ds = new DisplaySource();
            ds.GetDisplayObjects();
            this.neurons = new ObservableCollection<DisplayNeuron>(ds.Neurons);
            this.synapses = new ObservableCollection<DisplaySynapse>(ds.Synapses);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

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
