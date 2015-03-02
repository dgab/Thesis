using ExcelAddIn.Excel;
using NeuralNet.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace ExcelAddIn.Train
{
    class TrainViewModel : ViewModel
    {
        public BindingList<TrainingSample> TrainingSamples { get; set; }

        private TrainingSample selectedItem;

        public TrainingSample SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public TrainViewModel()
        {
            TrainingSamples = new BindingList<TrainingSample>();
        }

        private ICommand importCommand;
        public ICommand ImportCommand
        {
            get
            {
                if (importCommand == null)
                {
                    importCommand = new CommandHandler(() => GetTrainingSamplesFromExelSheet(), true);
                }
                return importCommand;
            }

        }

        private void GetTrainingSamplesFromExelSheet()
        {
            /*Application ExApp = Globals.ThisAddIn.Application as Application;
            Range SelectedRange = ExApp.Selection as Range;*/
            ExcelRepresenter representer = ExcelRepresenter.GetCurrentWorkSheet();
            DataTable dt = representer.GetSelectedCells();

            TrainingSamples.Clear();

            int input = 0;
            int target = 0;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string asd = dt.Rows[0][i].ToString();
                if (asd == "in")
                {
                    input++;
                }
                else
                {
                    target++;
                }
            }

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                List<double> inputs = new List<double>();
                List<double> targets = new List<double>();

                for (int j = 0; j < input; j++)
                {
                    inputs.Add(Convert.ToDouble(dt.Rows[i][j]));
                }
                for (int k = input; k < dt.Columns.Count; k++)
                {
                    targets.Add(Convert.ToDouble(dt.Rows[i][k]));
                }

                TrainingSample ts = new TrainingSample(inputs, targets);
                TrainingSamples.Add(ts);
            }
        }
    }
}
