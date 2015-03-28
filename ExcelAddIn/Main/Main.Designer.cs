namespace ExcelAddIn
{
    partial class Main : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Main()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpTaskPane = this.Factory.CreateRibbonGroup();
            this.tbtnShowHide = this.Factory.CreateRibbonToggleButton();
            this.btnShowNet = this.Factory.CreateRibbonButton();
            this.btnAbout = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpTaskPane.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpTaskPane);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // grpTaskPane
            // 
            this.grpTaskPane.Items.Add(this.tbtnShowHide);
            this.grpTaskPane.Items.Add(this.btnShowNet);
            this.grpTaskPane.Items.Add(this.btnAbout);
            this.grpTaskPane.Label = "Neural Net";
            this.grpTaskPane.Name = "grpTaskPane";
            // 
            // tbtnShowHide
            // 
            this.tbtnShowHide.Label = "tbtnShowHide";
            this.tbtnShowHide.Name = "tbtnShowHide";
            this.tbtnShowHide.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnShowHide_Click);
            // 
            // btnShowNet
            // 
            this.btnShowNet.Enabled = false;
            this.btnShowNet.Label = "Show Net";
            this.btnShowNet.Name = "btnShowNet";
            this.btnShowNet.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnShowNet_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Label = "About";
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAbout_Click);
            // 
            // Main
            // 
            this.Name = "Main";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Main_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpTaskPane.ResumeLayout(false);
            this.grpTaskPane.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpTaskPane;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton tbtnShowHide;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnShowNet;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAbout;
    }

    partial class ThisRibbonCollection
    {
        internal Main Main
        {
            get { return this.GetRibbon<Main>(); }
        }
    }
}
