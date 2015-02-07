using System.Windows.Controls;

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
    }
}
