using Microsoft.Office.Interop.Excel;
using NeuralNet.Training;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Input;

namespace ExcelAddIn.Train
{
    class TrainViewModel : ViewModel
    {
        public List<TrainingSample> TrainingSamples { get; set; }

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
            TrainingSamples = new List<TrainingSample>();
            List<double> inputs = new List<double>() { 1, 2, 3, 4 };
            List<double> outputs = new List<double>() { 1, 2, 3, 4 };
            TrainingSample a = new TrainingSample(inputs, outputs);
            TrainingSamples.Add(a);
            TrainingSamples.Add(a);
            TrainingSamples.Add(a);
            TrainingSamples.Add(a);
            TrainingSamples.Add(a);
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
            Application ExApp = Globals.ThisAddIn.Application as Application;
            Range SelectedRange = ExApp.Selection as Range;
            
        }
    }
}
