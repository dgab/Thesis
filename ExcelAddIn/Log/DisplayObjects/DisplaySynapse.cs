
namespace ExcelAddIn.Log
{
    public class DisplaySynapse : DisplayObject
    {
        public override double X
        {
            get { return 0; }
            set { }
        }

        public override double Y
        {
            get { return 0; }
            set { }
        }

        private DisplayNeuron _start;
        public DisplayNeuron Start
        {
            get { return _start; }
            set
            {
                _start = value;
                OnPropertyChanged("Start");
            }
        }

        private DisplayNeuron _end;
        public DisplayNeuron End
        {
            get { return _end; }
            set
            {
                _end = value;
                OnPropertyChanged("End");
            }
        }
    }
}
