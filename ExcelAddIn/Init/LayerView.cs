
using NeuralNet.Functions;
namespace ExcelAddIn.Init
{
    public class LayerView
    {
        public string Type { get; set; }

        private int numberOfNeurons;
        public int NumberOfNeurons
        {
            get
            {
                return this.numberOfNeurons;
            }
            set
            {
                if (value > 0)
                {
                    this.numberOfNeurons = value;
                }
            }
        }

        public TransferFunctions Function { get; set; }

        public LayerView(string type, int numberOfNeurons, TransferFunctions function)
        {
            this.Type = type;
            this.NumberOfNeurons = numberOfNeurons;
            this.Function = function;
        }
    }
}
