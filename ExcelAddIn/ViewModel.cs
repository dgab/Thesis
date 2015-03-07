
using System.ComponentModel;
using System.Windows.Input;
namespace ExcelAddIn
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Execute(ICommand command)
        {
            command.Execute(null);
        }
    }
}
