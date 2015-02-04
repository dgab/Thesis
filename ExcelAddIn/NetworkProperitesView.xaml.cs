using NeuralNet;
using NeuralNet.Layers;
using NeuralNet.Neurons;
using NeuralNet.Training;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ExcelAddIn
{
    /// <summary>
    /// Interaction logic for NetworkProperitesView.xaml
    /// </summary>
    public partial class NetworkProperitesView : Window
    {
        public NetworkProperitesView()
        {
            InitializeComponent();

            BackpropNetwork bpn = new BackpropNetwork();
            bpn.Initialize(8, 6, 2);
            TrainingSet ts = new TrainingSet(bpn.Layers.InputLayer, bpn.Layers.OutputLayer);
            ts.Add(new TrainingSample(new List<double>() { 1, 0, 1, 0, 1, 0, 1, 0 }, new List<double> { 0.4, 0.9 }));
            ts.Add(new TrainingSample(new List<double>() { 1, 1, 1, 1, 1, 1, 1, 1 }, new List<double> { 0.2, 0.3 }));
            ts.Add(new TrainingSample(new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0 }, new List<double> { 0.3, 0.5 }));
            bpn.Train(ts, int.MaxValue, 0.0000001);

            logView.DataContext = bpn;
        }
    }
}
