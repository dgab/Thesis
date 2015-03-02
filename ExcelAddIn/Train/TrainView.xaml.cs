using System.Windows.Controls;

namespace ExcelAddIn.Train
{
    /// <summary>
    /// Interaction logic for TrainView.xaml
    /// </summary>
    public partial class TrainView : UserControl
    {
        public TrainView()
        {
            InitializeComponent();
            this.DataContext = new TrainViewModel();
        }
    }
}
