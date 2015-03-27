using ExcelAddIn.Log;
using NeuralNet.Extensions;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ExcelAddIn
{
    /// <summary>
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
            this.DataContext = new LogViewModel();
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var neuron = ((Thumb)sender).DataContext as DisplayNeuron;
            if (neuron == null)
                return;

            neuron.X += e.HorizontalChange;
            neuron.Y += e.VerticalChange;
        }

        private void view_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = this.DataContext.As<LogViewModel>();
            viewModel.AreaHeight = viewModel.Neurons.Max(_ => _.Y) + 50;
            viewModel.AreaWidth = viewModel.Neurons.Max(_ => _.X) + 50;
        }
    }
}
