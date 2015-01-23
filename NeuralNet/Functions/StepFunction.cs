
namespace NeuralNet.Functions
{
    public class StepFunction : IFunction
    {
        public double ApplyFunction(double x)
        {
            if (x >= 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public double Derivative(double x)
        {
            return 0;
        }
    }
}
