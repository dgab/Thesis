
using NeuralNet.Training;
using System.Data;
namespace ExcelAddIn.Excel
{
    interface ITrainingSetConverter
    {
        TrainingSet ConvertToTrainingSet(DataTable table, int inputNeurons, int outputNeurons);

        void FormatAndValidateDataTable(DataTable table, int inputNeurons, int outputNeurons);
    }
}
