using System;
using System.Windows;
using System.Windows.Controls;

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

        public void OnErrorEvent(object sender, RoutedEventArgs e)
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

        public override string ToString()
        {
            return "Initialize";
        }
    }
}
