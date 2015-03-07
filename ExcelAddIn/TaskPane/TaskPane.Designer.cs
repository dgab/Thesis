namespace ExcelAddIn
{
    partial class TaskPane
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.taskPaneViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.host = new System.Windows.Forms.Integration.ElementHost();
            this.trainView1 = new ExcelAddIn.Train.TrainView();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskPaneViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBox
            // 
            this.grpBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox.Controls.Add(this.host);
            this.grpBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.taskPaneViewModelBindingSource, "GroupBoxName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.grpBox.Location = new System.Drawing.Point(4, 4);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(323, 351);
            this.grpBox.TabIndex = 1;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "groupBox1";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.taskPaneViewModelBindingSource, "NextCommand", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnNext.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.taskPaneViewModelBindingSource, "NextEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnNext.Location = new System.Drawing.Point(246, 361);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.EventCall);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.taskPaneViewModelBindingSource, "PreviousCommand", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnBack.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.taskPaneViewModelBindingSource, "BackEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnBack.Location = new System.Drawing.Point(10, 361);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.EventCall);
            // 
            // taskPaneViewModelBindingSource
            // 
            this.taskPaneViewModelBindingSource.DataSource = typeof(ExcelAddIn.TaskPaneViewModel);
            // 
            // host
            // 
            this.host.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.host.DataBindings.Add(new System.Windows.Forms.Binding("Child", this.taskPaneViewModelBindingSource, "CurrentControl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.host.Location = new System.Drawing.Point(6, 19);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(311, 326);
            this.host.TabIndex = 0;
            this.host.Child = this.trainView1;
            // 
            // TaskPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.grpBox);
            this.Name = "TaskPane";
            this.Size = new System.Drawing.Size(330, 393);
            this.grpBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taskPaneViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost host;
        private Train.TrainView trainView1;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.BindingSource taskPaneViewModelBindingSource;
    }
}
