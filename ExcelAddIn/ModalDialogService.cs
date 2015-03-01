using System.Threading;
using System.Windows;

namespace ExcelAddIn
{
    public enum WindowTypes
    {
        TrainWindow,
        NetworkProperties
    }
    static class ModalDialogService
    {
        private static Thread thread;

        public static void Show(WindowTypes type)
        {
            thread = new Thread(() => WindowFactory.CreateWindow(type));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }

    static class WindowFactory
    {
        public static void CreateWindow(WindowTypes type)
        {
            Window window;

            switch (type)
            {
                case WindowTypes.TrainWindow:
                    window = new Train.TrainWindow();
                    break;
                case WindowTypes.NetworkProperties:
                    window = new NetworkProperitesView();
                    break;
                default:
                    window = null;
                    break;
            }
            if (window != null)
            {
                window.ShowDialog();
            }
        }
    }
}
