using ExcelAddIn.Excel;
using ExcelAddIn.Import;
using NeuralNet.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace ExcelAddIn.Train
{
    class TrainViewModel : ViewModel
    {
        private SynchronizationContext uiContext;

        public AutoScrollingListView Listview { get; set; }

        private double eta = 0.8;

        public double Eta
        {
            get { return eta; }
            set { eta = value; }
        }

        private double momentum = 0.2;

        public double Momentum
        {
            get { return momentum; }
            set { momentum = value; }
        }

        private double error = 0.00001;

        public double Error
        {
            get { return error; }
            set { error = value; }
        }

        private int iteration = 100000;

        public int Iteration
        {
            get { return iteration; }
            set { iteration = value; }
        }



        public BindingList<double> Errors { get; set; }

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

        private bool trainEnabled = true;

        public bool TrainEnabled
        {
            get
            {
                return trainEnabled;
            }
            set
            {
                trainEnabled = value;
                OnPropertyChanged("TrainEnabled");
            }
        }

        private bool stopEnabled;

        public bool StopEnabled
        {
            get
            {
                return stopEnabled;
            }
            set
            {
                stopEnabled = value;
                OnPropertyChanged("StopEnabled");
            }
        }



        public TrainViewModel()
        {
            TrainingSamples = new BindingList<TrainingSample>();
            Errors = new BindingList<double>();
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

        private ICommand trainCommand;

        public ICommand TrainCommand
        {
            get
            {
                if (trainCommand == null)
                {
                    trainCommand = new CommandHandler(() => BeginTrain(), true);
                }
                return trainCommand;
            }
        }

        private ICommand stopCommand;

        public ICommand StopCommand
        {
            get
            {
                if (stopCommand == null)
                {
                    stopCommand = new CommandHandler(() => StopTraining(), true);
                }
                return stopCommand;
            }
        }

        private ICommand removeCommand;

        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                {
                    this.removeCommand = new CommandHandler(() => Remove(), true);
                }
                return this.removeCommand;
            }
        }

        private ICommand removeAllCommand;
        public ICommand RemoveAllCommand
        {
            get
            {
                if (this.removeAllCommand == null)
                {
                    this.removeAllCommand = new CommandHandler(() => RemoveAll(), true);
                }
                return this.removeAllCommand;
            }
        }
        private void GetTrainingSamplesFromExelSheet()
        {
            IExcelRepresenter representer = new ExcelRepresenter();
            try
            {
                DataTable selectedCells = representer.ConvertSelectedRangeToDataTable();
                ImportView view = new ImportView(selectedCells);
                view.OnImported += view_OnImported;
                view.Show();
            }
            catch (RangeWasNullException)
            {
                MessageBox.Show("No cells were selected! Select some.", "Neural Net", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        void view_OnImported(object sender, System.EventArgs e)
        {
            this.TrainingSamples.Clear();

            DataTable dt = (DataTable)sender;

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

        public void Remove()
        {
            this.TrainingSamples.Remove(this.SelectedItem);
        }

        public void RemoveAll()
        {
            this.TrainingSamples.Clear();
        }
        public void BeginTrain()
        {
            uiContext = SynchronizationContext.Current;

            Errors.Clear();

            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                this.TrainEnabled = false;
                this.StopEnabled = true;
                worker.RunWorkerAsync();
            }
        }

        public void StopTraining()
        {
            Network.Default.StopTraining();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Network.Default.Eta = this.Eta;
            Network.Default.Momentum = this.Momentum;
            Network.Default.TrainingSet = new TrainingSet(Network.Default.Layers.InputLayer, Network.Default.Layers.OutputLayer);
            foreach (TrainingSample item in this.TrainingSamples)
            {
                Network.Default.TrainingSet.Add(item);
            }

            Network.Default.TrainingEpochEvent += Default_TrainingEpochEvent;
            Network.Default.Train(Network.Default.TrainingSet, this.Iteration, this.Error);//Trainingset nem nagyon kéne...
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Network.Default.TrainingEpochEvent -= Default_TrainingEpochEvent; //Le kell róla íratkozni, mert a következő indításkor már kétszer íratkozik fel, stb...
            this.TrainEnabled = true;
            this.StopEnabled = false;
        }

        void Default_TrainingEpochEvent(object sender, TrainingEpochEventArgs e)
        {
            if (Errors.Count >= 100)
            {
                uiContext.Send(x => Errors.RemoveAt(99), null);
            }
            if (e.CurrentIteration % 1000 == 0 || e.CurrentIteration == 1 || e.CurrentIteration == this.Iteration)
            {
                uiContext.Send(x => Errors.Insert(0, e.Error), null);
            }

            //uiContext.Send(x => Listview);
            //Errors.Add(e.Error);
        }
    }
}
