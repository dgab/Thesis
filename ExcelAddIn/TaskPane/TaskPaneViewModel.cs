using ExcelAddIn.Init;
using ExcelAddIn.Test;
using ExcelAddIn.Train;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExcelAddIn
{
    class TaskPaneViewModel : ViewModel
    {
        private static UserControl init = new InitView();

        private static UserControl train = new TrainView();

        private static UserControl test = new TestView();

        private IList<UserControl> userControls;

        private UserControl currentControl = GetStartingControl();

        private int currentIndex
        {
            get
            {
                return userControls.IndexOf(currentControl);
            }
        }

        public bool NextEnabled
        {
            get
            {
                return (Network.Default.Initialized) && (userControls.Count != currentIndex + 1);
            }
            set
            {
                OnPropertyChanged("NextEnabled");
            }
        }

        public bool BackEnabled
        {
            get
            {
                return currentIndex != 0;
            }
        }
        public UserControl CurrentControl
        {
            get
            {
                return currentControl;
            }
            set
            {
                currentControl = value;
                OnPropertyChanged("CurrentControl");
            }
        }

        private ICommand nextCommand;

        public ICommand NextCommand
        {
            get
            {
                if (nextCommand == null)
                {
                    nextCommand = new CommandHandler(Next, true);
                }
                return this.nextCommand;
            }
        }

        private ICommand previousCommand;

        public ICommand PreviousCommand
        {
            get
            {
                if (previousCommand == null)
                {
                    previousCommand = new CommandHandler(Previous, true);
                }
                return this.previousCommand;
            }
        }

        public string GroupBoxName
        {
            get
            {
                return CurrentControl.ToString();
            }
        }
        public TaskPaneViewModel()
        {
            userControls = new List<UserControl> { init, train, test };
            this.CurrentControl = init;
            Network.OnNetworkChanged += Network_OnNetworkChanged;
        }

        void Network_OnNetworkChanged(object sender, System.EventArgs e)
        {
            this.NextEnabled = true;
            //This is dummy data, NextEnabled setter only calls the OnPropertyChanged
        }

        private static UserControl GetStartingControl()
        {
            if (!Network.Default.Initialized)
            {
                return init;
            }
            else
            {
                return train;
            }
        }

        private void Next()
        {
            CurrentControl = userControls[currentIndex + 1];
        }

        private void Previous()
        {
            CurrentControl = userControls[currentIndex - 1];
        }
    }
}
