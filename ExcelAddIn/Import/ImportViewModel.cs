using ExcelAddIn.Excel;
using ExcelAddIn.Exceptions;
using System;
using System.Data;

namespace ExcelAddIn.Import
{
    class ImportViewModel : ViewModel
    {
        public DataTable DataSource { get; private set; }

        public string ErrorMessage { get; private set; }

        private readonly ITrainingSetConverter converter;
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
            this.converter = new TrainingSetConverter();

            try
            {
                this.converter.FormatAndValidateDataTable(this.DataSource, Network.InputNeurons, Network.OutputNeurons);
            }
            catch (InvalidNumberOfColumnsException)
            {
                ErrorMessage = "The number of columns in the selection must match with the sum of the neurons on the input and output layer.\nYou can set the number of neurons in the initializitaion view.";
                this.DataSource = null;
            }
            catch (InvalidCastException)
            {
                ErrorMessage = "There are non-numeric fields in the selection. Please close the form, and resolve this issue in excel.";
                this.DataSource = null;
            }
        }
    }
}
