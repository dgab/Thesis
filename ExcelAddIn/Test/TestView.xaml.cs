using System.Windows.Controls;

namespace ExcelAddIn.Test
{
    /// <summary>
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView : UserControl
    {
        public TestView()
        {
            InitializeComponent();
            this.DataContext = new TestViewModel();
        }

        public override string ToString()
        {
            return "Testing";
        }
    }
}
