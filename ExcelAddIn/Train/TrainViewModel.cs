using ExcelAddIn.Excel;
using NeuralNet.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
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

        public void BeginTrain()
        {
            uiContext = SynchronizationContext.Current;

            Errors.Clear();

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
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
