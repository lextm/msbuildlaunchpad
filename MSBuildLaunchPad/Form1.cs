using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace MSBuildLaunchPad
{
    public partial class Form1 : Form
    {
        public string FileName { get; set; }

        private const string Title = "MSBuild Launch Pad (Version: {1}) - {0}";

        public Form1(string fileName)
        {
            FileName = fileName;
            InitializeComponent();
            IParser parser = ParserFactory.Parse(fileName);
            tscbVersion.SelectedIndex = parser.Version;
        }

        private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
        {
            MSBuildTask task = (MSBuildTask) e.Argument;
            e.Result = task.Execute();
        }

        private void BackgroundWorker1ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void BackgroundWorker1RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tsbtnStart.Enabled = true;
            string[] data = (string[]) e.Result;
            tspbProgress.Style = ProgressBarStyle.Continuous; 
            tspbProgress.MarqueeAnimationSpeed = 0;
            tspbProgress.Value = 100;
            if (!string.IsNullOrEmpty(data[0]))
            {
                MessageBox.Show(data[0]);
            }
            // MessageBox.Show("output: " + data[1] + "; error: " + data[0]);
            // TODO: parse data to list view.
        }

        private void TsbtnStartClick(object sender, EventArgs e)
        {
            tsbtnStart.Enabled = false;
            tspbProgress.Style = ProgressBarStyle.Marquee;
            tspbProgress.MarqueeAnimationSpeed = 30; 
            backgroundWorker1.RunWorkerAsync(new MSBuildTask(FileName, tscbVersion.Text, tscbConfiguration.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = string.Format(CultureInfo.InvariantCulture, Title, FileName, Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}
