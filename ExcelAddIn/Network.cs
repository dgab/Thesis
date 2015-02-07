using NeuralNet;

namespace ExcelAddIn
{
    public static class Network
    {
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
    }
}
