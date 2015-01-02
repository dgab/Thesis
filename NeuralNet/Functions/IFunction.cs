
namespace NeuralNet.Functions
{
    public interface IFunction
    {
        /// <summary>
        /// As a result this void should set the output value of n.
        /// </summary>
        /// <param name="n"></param>
        double ApplyFunction(double x);


    }
}
