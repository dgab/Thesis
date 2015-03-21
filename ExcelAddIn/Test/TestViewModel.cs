using ExcelAddIn.Excel;
using NeuralNet.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace ExcelAddIn.Test
{
    class TestViewModel
    {
        public BindingList<TestResult> Errors { get; private set; }

        private List<TrainingSample> TrainingSamples;

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

        IExcelRepresenter excel;
        public TestViewModel()
        {
            excel = new ExcelRepresenter();
            this.Errors = new BindingList<TestResult>();
            this.TrainingSamples = new List<TrainingSample>();
        }

        private void Test()
        {
            DataTable dt = excel.ConvertSelectedRangeToDataTable();

            this.Errors.Clear();
            this.TrainingSamples.Clear();

            try
            {
                this.ProcessDataTable(dt);
            }
            catch (InvalidNumberOfColumnsException)
            {
                MessageBox.Show("The number of columns in the selection must match with the sum of input and outputlayer neurons.", "Neural Net", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("There were non numeric fields in the selection.", "Neural Net", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            foreach (TrainingSample ts in this.TrainingSamples)
            {
                this.Errors.Add(new TestResult(this.TrainingSamples.IndexOf(ts) + 1, Network.Default.Run(ts)));
            }
        }

        private void ProcessDataTable(DataTable dt)
        {
            int inputCount = Network.Default.Layers.InputLayer.Neurons.Count;
            int outputCount = Network.Default.Layers.OutputLayer.Neurons.Count;

            if (dt.Columns.Count != (inputCount - 1 + outputCount))
            {
                throw new InvalidNumberOfColumnsException();
            }


            for (int i = 0; i < inputCount - 1; i++)
            {
                dt.Columns[i].ColumnName = "Input" + (i + 1).ToString();
            }

            for (int i = inputCount - 1; i < inputCount + outputCount - 1; i++)
            {
                dt.Columns[i].ColumnName = "Target" + (i - inputCount + 2).ToString();
            }

            bool isNumeric = true;
            foreach (DataRow row in dt.Rows)
            {
                if (!isNumeric)
                {
                    break;
                }

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    double n = 0;
                    isNumeric = double.TryParse(row[i].ToString(), out n);

                    if (!isNumeric)
                    {
                        throw new InvalidCastException();
                    }
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                List<double> inputs = new List<double>();
                List<double> targets = new List<double>();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].ColumnName.StartsWith("Input"))
                    {
                        inputs.Add(Convert.ToDouble(row[i].ToString())); //at this point it surely is double
                    }
                    else
                    {
                        targets.Add(Convert.ToDouble(row[i].ToString()));
                    }
                }

                TrainingSample ts = new TrainingSample(inputs, targets);
                this.TrainingSamples.Add(ts);
            }
        }
    }
}
