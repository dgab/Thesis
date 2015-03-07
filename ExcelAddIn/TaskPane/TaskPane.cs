using NeuralNet.Extensions;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace ExcelAddIn
{
    public partial class TaskPane : UserControl
    {
        private readonly TaskPaneViewModel viewModel;

        public TaskPane()
        {
            InitializeComponent();
            this.viewModel = new TaskPaneViewModel();
            this.taskPaneViewModelBindingSource.DataSource = this.viewModel;
        }

        private void EventCall(object sender, EventArgs e)
        {
            Control send = sender.As<Control>();
            object tag = send.Tag;
            ICommand command = tag.As<ICommand>();
            viewModel.Execute(command);
        }
    }
}
