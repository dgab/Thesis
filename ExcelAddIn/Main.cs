using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
