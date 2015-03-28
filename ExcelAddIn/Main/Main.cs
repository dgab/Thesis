using Microsoft.Office.Tools;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Linq;

namespace ExcelAddIn
{
    //Databinding is not supported for office ribbons :'(
    public partial class Main
    {

        public string ShowHideButtonText
        {
            get { return this.tbtnShowHide.Label; }
            set { this.tbtnShowHide.Label = value; }
        }

        private void Main_Load(object sender, RibbonUIEventArgs e)
        {
            TaskPane tp = new TaskPane();
            Globals.ThisAddIn.CustomTaskPanes.Add(tp, "Neural Net");

            this.ShowHideButtonText = "Show Task Pane";

            Network.OnNetworkChanged += Network_OnNetworkChanged;
        }

        void Network_OnNetworkChanged(object sender, EventArgs e)
        {
            btnShowNet.Enabled = true;
        }


        private void btnShowHide_Click(object sender, RibbonControlEventArgs e)
        {
            CustomTaskPane pane = Globals.ThisAddIn.CustomTaskPanes.FirstOrDefault(x => x.Title == "Neural Net");

            if (pane == null)
            {
                throw new InvalidOperationException("There is no taskpane that meets the given condition!");
            }

            pane.Visible = !pane.Visible;
            this.ShowHideButtonText = pane.Visible == true ? "Hide Task Pane" : "Show Task Pane";
        }

        private void btnShowNet_Click(object sender, RibbonControlEventArgs e)
        {
            //ModalDialogService.Show(WindowTypes.NetworkProperties); //Suspicious thread error aka: cannot access object because different thread owns it. (object = window)
            NetworkProperitesView view = new NetworkProperitesView();
            view.ShowDialog();
        }

        private void btnAbout_Click(object sender, RibbonControlEventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }
    }
}
