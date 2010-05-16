using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lextm.MSBuildLaunchPad
{
    internal partial class Form1 : Form
    {
        private string FileName { get; set; }

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
            MSBuildTask task = (MSBuildTask)e.Argument;
            task.Execute();
        }

        private void BackgroundWorker1ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void BackgroundWorker1RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tsbtnStart.Enabled = true;
            tspbProgress.Style = ProgressBarStyle.Continuous; 
            tspbProgress.MarqueeAnimationSpeed = 0;
            tspbProgress.Value = 100;
            SetForegroundWindow(Handle);
        }

        private void TsbtnStartClick(object sender, EventArgs e)
        {
            tsbtnStart.Enabled = false;
            tspbProgress.Style = ProgressBarStyle.Marquee;
            tspbProgress.MarqueeAnimationSpeed = 30; 
            backgroundWorker1.RunWorkerAsync(new MSBuildTask(FileName, tscbVersion.Text, string.Format(CultureInfo.InvariantCulture, @"/t:{0} /p:Configuration={1}", tscbTarget.Text, tscbConfiguration.Text)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = string.Format(CultureInfo.InvariantCulture, Title, FileName, Assembly.GetExecutingAssembly().GetName().Version);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern void SetForegroundWindow(IntPtr handle);
    }
}
