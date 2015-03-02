using Microsoft.Office.Tools.Ribbon;

namespace ExcelAddIn
{
    public partial class Main
    {
        private void Main_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            ModalDialogService.Show(WindowTypes.NetworkProperties);
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            ModalDialogService.Show(WindowTypes.TrainWindow);
        }
    }
}
