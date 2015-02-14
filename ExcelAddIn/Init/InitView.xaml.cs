using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExcelAddIn.Init
{
    /// <summary>
    /// Interaction logic for InitView.xaml
    /// </summary>
    public partial class InitView : UserControl
    {
        InitViewModel model { get; set; }
        private int errorCount = 0;
        public InitView()
        {
            InitializeComponent();
            model = new InitViewModel();
            this.DataContext = model;
            ComboColumn.ItemsSource = model.Functions;

            AddHandler(Validation.ErrorEvent, new RoutedEventHandler(OnErrorEvent));
        }

        public void OnErrorEvent(object sender, RoutedEventArgs  e)
        {
            var validationEventArgs = e as ValidationErrorEventArgs;
            if (validationEventArgs == null)
                throw new Exception("Unexpected event args");
            switch (validationEventArgs.Action)
            {
                case ValidationErrorEventAction.Added:
                    {
                        errorCount++; break;
                    }
                case ValidationErrorEventAction.Removed:
                    {
                        errorCount--; break;
                    }
                default:
                    {
                        throw new Exception("Unknown action");
                    }
            }

            btnInit.IsEnabled = errorCount == 0;
        }
    }
}
