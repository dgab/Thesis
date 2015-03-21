using System;
using System.Data;
using System.Windows;

namespace ExcelAddIn.Import
{
    public delegate void Imported(object sender, EventArgs e);
    /// <summary>
    /// Interaction logic for ImportView.xaml
    /// </summary>
    public partial class ImportView : Window
    {


        public ImportView(DataTable table)
        {
            InitializeComponent();
            this.DataContext = new ImportViewModel(table);
        }

        public event Imported OnImported;

        public void OnImportedHandler(object sender, EventArgs e)
        {
            if (OnImported != null)
            {
                OnImported(sender, e);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnImportedHandler(((ImportViewModel)this.DataContext).DataSource, new EventArgs());
            this.Close();
        }
    }
}
