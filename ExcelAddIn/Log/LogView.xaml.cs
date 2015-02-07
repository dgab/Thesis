using ExcelAddIn.Log;
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
    }
}
