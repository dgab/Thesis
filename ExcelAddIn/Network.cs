using NeuralNet;
using System;

namespace ExcelAddIn
{
    public delegate void NetworkChanged(object sender, EventArgs e);
    public static class Network
    {
        public static event NetworkChanged OnNetworkChanged;

        public static void OnNetworkChangedHandler(object sender, EventArgs e)
        {
            if (OnNetworkChanged != null)
	        {
		        OnNetworkChanged(sender, e);
	        }
        }

        private static BackpropNetwork _default;
        public static BackpropNetwork Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new BackpropNetwork();
                }
                return _default;
            }
        }

        public static void Initialize(int[] sizes)
        {
            Network.Default.Initialize(sizes);
            OnNetworkChangedHandler(new object(), new EventArgs());
        }
    }
}
