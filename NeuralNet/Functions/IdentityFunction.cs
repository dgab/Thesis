using System.Xml.Serialization;

namespace NeuralNet.Functions
{
    [XmlRoot("IdentityFunction")]
    public class IdentityFunction : IFunction
    {
        public double ApplyFunction(double x)
        {
            return x;
        }

        public double Derivative(double x)
        {
            return 1;
        }
    }
}
