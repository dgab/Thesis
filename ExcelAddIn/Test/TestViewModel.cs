using ExcelAddIn.Excel;
using ExcelAddIn.Exceptions;
using NeuralNet.Training;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace ExcelAddIn.Test
{
    class TestViewModel
    {
        public BindingList<TestResult> Errors { get; private set; }

        private TrainingSet trainingSet;

        private ICommand testCommand;
        public ICommand TestCommand
        {
            get
            {
                if (this.testCommand == null)
                {
                    this.testCommand = new CommandHandler(this.Test, true);
                }
                return this.testCommand;
            }
        }

        private IExcelRepresenter excel;

        private ITrainingSetConverter converter;
        public TestViewModel()
        {
            this.excel = new ExcelRepresenter();
            this.Errors = new BindingList<TestResult>();
            this.converter = new TrainingSetConverter();
        }

        private void Test()
        {
            DataTable dt = excel.ConvertSelectedRangeToDataTable();

            this.Errors.Clear();

            try
            {
                this.trainingSet = converter.ConvertToTrainingSet(dt, Network.InputNeurons, Network.OutputNeurons);

                foreach (TrainingSample ts in this.trainingSet)
                {
                    this.Errors.Add(new TestResult(this.trainingSet.IndexOf(ts) + 1, Network.Default.Run(ts)));
                }
            }
            catch (InvalidNumberOfColumnsException)
            {
                MessageBox.Show("The number of columns in the selection must match with the sum of input and outputlayer neurons.", "Neural Net", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("There were non numeric fields in the selection.", "Neural Net", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
