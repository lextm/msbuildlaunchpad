namespace MSBuildLaunchPad
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnStart = new System.Windows.Forms.ToolStripButton();
            this.tscbConfiguration = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbVersion = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnErrors = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnWarnings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnMessages = new System.Windows.Forms.ToolStripButton();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lvErrorList = new System.Windows.Forms.ListView();
            this.chIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnStart,
            this.tscbConfiguration,
            this.toolStripLabel1,
            this.tscbVersion,
            this.tsbtnSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(588, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbtnStart
            // 
            this.tsbtnStart.Image = global::MSBuildLaunchPad.Properties.Resources.FormRunHS;
            this.tsbtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStart.Name = "tsbtnStart";
            this.tsbtnStart.Size = new System.Drawing.Size(51, 22);
            this.tsbtnStart.Text = "Start";
            this.tsbtnStart.Click += new System.EventHandler(this.TsbtnStartClick);
            // 
            // tscbConfiguration
            // 
            this.tscbConfiguration.Items.AddRange(new object[] {
            "/t:Build /p:Configuration=Debug",
            "/t:Build /p:Configuration=Release",
            "/t:Clean"});
            this.tscbConfiguration.Name = "tscbConfiguration";
            this.tscbConfiguration.Size = new System.Drawing.Size(200, 25);
            this.tscbConfiguration.Text = "/t:Build /p:Configuration=Debug";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(93, 22);
            this.toolStripLabel1.Text = "MSBuild Version";
            // 
            // tscbVersion
            // 
            this.tscbVersion.Items.AddRange(new object[] {
            "v2.0.50727",
            "v3.5",
            "v4.0.30319"});
            this.tscbVersion.Name = "tscbVersion";
            this.tscbVersion.Size = new System.Drawing.Size(121, 25);
            this.tscbVersion.Text = "v2.0.50727";
            // 
            // tsbtnSettings
            // 
            this.tsbtnSettings.Image = global::MSBuildLaunchPad.Properties.Resources._327_Options_16x16_72;
            this.tsbtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSettings.Name = "tsbtnSettings";
            this.tsbtnSettings.Size = new System.Drawing.Size(69, 22);
            this.tsbtnSettings.Text = "Settings";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnErrors,
            this.toolStripSeparator1,
            this.tsbtnWarnings,
            this.toolStripSeparator2,
            this.tsbtnMessages,
            this.tspbProgress});
            this.toolStrip2.Location = new System.Drawing.Point(0, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(588, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbtnErrors
            // 
            this.tsbtnErrors.CheckOnClick = true;
            this.tsbtnErrors.Image = global::MSBuildLaunchPad.Properties.Resources.errors;
            this.tsbtnErrors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnErrors.Name = "tsbtnErrors";
            this.tsbtnErrors.Size = new System.Drawing.Size(57, 22);
            this.tsbtnErrors.Text = "Errors";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnWarnings
            // 
            this.tsbtnWarnings.CheckOnClick = true;
            this.tsbtnWarnings.Image = global::MSBuildLaunchPad.Properties.Resources.WarningHS;
            this.tsbtnWarnings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnWarnings.Name = "tsbtnWarnings";
            this.tsbtnWarnings.Size = new System.Drawing.Size(77, 22);
            this.tsbtnWarnings.Text = "Warnings";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnMessages
            // 
            this.tsbtnMessages.CheckOnClick = true;
            this.tsbtnMessages.Image = global::MSBuildLaunchPad.Properties.Resources.info;
            this.tsbtnMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMessages.Name = "tsbtnMessages";
            this.tsbtnMessages.Size = new System.Drawing.Size(78, 22);
            this.tsbtnMessages.Text = "Messages";
            // 
            // tspbProgress
            // 
            this.tspbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(100, 22);
            // 
            // lvErrorList
            // 
            this.lvErrorList.AllowColumnReorder = true;
            this.lvErrorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chIcon,
            this.chIndex,
            this.chDescription,
            this.chFile,
            this.chLine,
            this.chColumn,
            this.chProject});
            this.lvErrorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvErrorList.FullRowSelect = true;
            this.lvErrorList.GridLines = true;
            this.lvErrorList.Location = new System.Drawing.Point(0, 50);
            this.lvErrorList.Name = "lvErrorList";
            this.lvErrorList.Size = new System.Drawing.Size(588, 248);
            this.lvErrorList.TabIndex = 2;
            this.lvErrorList.UseCompatibleStateImageBehavior = false;
            this.lvErrorList.View = System.Windows.Forms.View.Details;
            // 
            // chIcon
            // 
            this.chIcon.Text = "";
            // 
            // chIndex
            // 
            this.chIndex.Text = "";
            // 
            // chDescription
            // 
            this.chDescription.Text = "Description";
            // 
            // chFile
            // 
            this.chFile.Text = "File";
            // 
            // chLine
            // 
            this.chLine.Text = "Line";
            // 
            // chColumn
            // 
            this.chColumn.Text = "Column";
            // 
            // chProject
            // 
            this.chProject.Text = "Project";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 298);
            this.Controls.Add(this.lvErrorList);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = global::MSBuildLaunchPad.Properties.Resources.MSBuild_APPICON;
            this.Name = "Form1";
            this.Text = "MSBuild Launch Pad";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscbVersion;
        private System.Windows.Forms.ToolStripButton tsbtnStart;
        private System.Windows.Forms.ToolStripComboBox tscbConfiguration;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbtnErrors;
        private System.Windows.Forms.ToolStripButton tsbtnWarnings;
        private System.Windows.Forms.ToolStripButton tsbtnMessages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
        private System.Windows.Forms.ListView lvErrorList;
        private System.Windows.Forms.ColumnHeader chIcon;
        private System.Windows.Forms.ColumnHeader chIndex;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.ColumnHeader chFile;
        private System.Windows.Forms.ColumnHeader chLine;
        private System.Windows.Forms.ColumnHeader chColumn;
        private System.Windows.Forms.ColumnHeader chProject;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton tsbtnSettings;
    }
}

