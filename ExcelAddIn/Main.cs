using ExcelAddIn.Train;
using Microsoft.Office.Tools.Ribbon;
using NeuralNet;

namespace ExcelAddIn
{
    public partial class Main
    {
        private void Main_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            NetworkProperitesView mv = new NetworkProperitesView();
            mv.DataContext = new BackpropNetwork();
            mv.ShowDialog();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            ModalDialogService.Show(WindowTypes.TrainWindow);
        }
    }
}
