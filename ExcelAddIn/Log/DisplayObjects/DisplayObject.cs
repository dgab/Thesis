
using System.ComponentModel;
namespace ExcelAddIn.Log
{
    public abstract class DisplayObject : INotifyPropertyChanged
    {

        public abstract double X { get; set; }

        public abstract double Y { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
