using ExcelAddIn.Exceptions;
using NeuralNet.Training;
using System;
using System.Collections.Generic;
using System.Data;

namespace ExcelAddIn.Excel
{
    class TrainingSetConverter : ITrainingSetConverter
    {
        private int inputNeurons;

        private int outputNeurons;

        private DataTable dataTable;

        public TrainingSet ConvertToTrainingSet(DataTable table, int inputNeurons, int outputNeurons)
        {
            this.dataTable = table;
            this.inputNeurons = inputNeurons;
            this.outputNeurons = outputNeurons;

            this.ValidateDataTable();
            this.RenameColumnHeaders();
            this.CheckForNonNumericFields();
            return this.ConcreteConvert();
        }

        private void ValidateDataTable()
        {
            if (this.dataTable.Columns.Count != (inputNeurons + outputNeurons))
            {
                throw new InvalidNumberOfColumnsException("The number of columns in the selection must match with the sum of the neurons on the input and output layer.");
            }
        }

        private void RenameColumnHeaders()
        {
            for (int i = 0; i < inputNeurons; i++)
            {
                this.dataTable.Columns[i].ColumnName = string.Format("Input{0}", i);
            }
            for (int i = inputNeurons; i < inputNeurons + outputNeurons; i++)
            {
                this.dataTable.Columns[i].ColumnName = string.Format("Target{0}", i - inputNeurons + 1);
            }
        }

        private void CheckForNonNumericFields()
        {
            foreach (DataRow row in this.dataTable.Rows)
            {
                for (int i = 0; i < this.dataTable.Columns.Count; i++)
                {
                    double n = 0;

                    if (!double.TryParse(row[i].ToString(), out n))
                    {
                        throw new InvalidCastException("There are non-numeric fields in the selection. Please close the form, and resolve this issue in excel.");
                    }
                }
            }
        }

        private TrainingSet ConcreteConvert()
        {
            TrainingSet trainingSet = new TrainingSet(inputNeurons, outputNeurons);
            foreach (DataRow row in this.dataTable.Rows)
            {
                List<double> inputs = new List<double>();
                List<double> targets = new List<double>();

                for (int i = 0; i < this.dataTable.Columns.Count; i++)
                {
                    if (this.dataTable.Columns[i].ColumnName.StartsWith("Input"))
                    {
                        inputs.Add(Convert.ToDouble(row[i].ToString())); //at this point it surely is double
                    }
                    else
                    {
                        targets.Add(Convert.ToDouble(row[i].ToString()));
                    }
                }

                TrainingSample ts = new TrainingSample(inputs, targets);
                trainingSet.Add(ts);
            }
            return trainingSet;
        }
    }
}
