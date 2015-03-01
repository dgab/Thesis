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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TrainWindow tv = new TrainWindow();
            tv.Show();
        }
    }
}
