using System.Data;

namespace ExcelAddIn.Import
{
    class ImportViewModel : ViewModel
    {
        public DataTable DataSource { get; private set; }

        public string ErrorMessage { get; private set; }

        public bool ImportEnabled
        {
            get
            {
                return string.IsNullOrEmpty(this.ErrorMessage);
            }
        }
        public ImportViewModel(DataTable table)
        {
            this.DataSource = table;
            this.ProcessDatatable();
        }

        private void ProcessDatatable()
        {
            //Wow ez így szar.
            int inputColumns = Network.Default.Layers.InputLayer.Neurons.Count;
            int outputColumns = Network.Default.Layers.OutputLayer.Neurons.Count;

            if (DataSource.Columns.Count != (inputColumns - 1 + outputColumns))
            {
                DataSource = null;
                ErrorMessage = "The number of columns in the selection must match with the sum of the neurons on the input and output layer.\nYou can set the number of neurons in the initializitaion view.";
            }
            else
            {
                for (int i = 0; i < inputColumns - 1; i++)
                {
                    this.DataSource.Columns[i].ColumnName = "Input" + (i + 1).ToString();
                }

                for (int i = inputColumns - 1; i < inputColumns + outputColumns - 1; i++)
                {
                    this.DataSource.Columns[i].ColumnName = "Target" + (i - inputColumns + 2).ToString();
                }
            }

            if (this.DataSource != null)
            {
                bool isNumeric = true;
                foreach (DataRow row in this.DataSource.Rows)
                {
                    if (!isNumeric)
                    {
                        break;
                    }

                    for (int i = 0; i < this.DataSource.Columns.Count; i++)
                    {
                        double n = 0;
                        isNumeric = double.TryParse(row[i].ToString(), out n);

                        if (!isNumeric)
                        {
                            ErrorMessage = "There are non-numeric fields in the selection. Please close the form, and resolve this issue in excel.";
                            break;
                        }
                    }
                }
            }
        }
    }
}
