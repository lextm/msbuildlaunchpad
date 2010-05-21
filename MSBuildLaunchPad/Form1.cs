using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

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
            foreach (var target in parser.Targets)
            {
                tscbTarget.Items.Add(target);
            }

            RegistryKey options = Registry.CurrentUser.OpenSubKey(@"Software\LeXtudio\MSBuildLaunchPad\MainForm");
            if (options == null)
            {
                return;
            }

            tscbTarget.Text = options.GetValue("Target", "Build").ToString();
            tscbConfiguration.Text = options.GetValue("Configuration", "Debug").ToString();
            tsbtnAutoHide.Checked = Convert.ToBoolean(options.GetValue("AutoHide", "False"), CultureInfo.InvariantCulture);
            tsbtnShowPrompt.Checked = Convert.ToBoolean(options.GetValue("ShowPrompt", "False"), CultureInfo.InvariantCulture);
            
            RegistryKey editor = Registry.CurrentUser.OpenSubKey(@"Software\Ardal\MSBuildShellExtension\Editors\Notepad");
            if (editor != null)
            {
                return;
            }
            
            editor = Registry.CurrentUser.CreateSubKey(@"Software\Ardal\MSBuildShellExtension\Editors\Notepad");
            editor.SetValue("Arguments", "{file}");
            editor.SetValue("DefaultEditor", "True");
            editor.SetValue("Filename", "notepad.exe");
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
            NativeMethods.SetForegroundWindow(Handle);
            if (tsbtnAutoHide.Checked)
            {
                Close();
            }
        }

        private void TsbtnStartClick(object sender, EventArgs e)
        {
            tsbtnStart.Enabled = false;
            tspbProgress.Style = ProgressBarStyle.Marquee;
            tspbProgress.MarqueeAnimationSpeed = 30; 
            backgroundWorker1.RunWorkerAsync(new MSBuildTask(FileName, tscbVersion.Text, string.Format(CultureInfo.InvariantCulture, @"/t:{0} /p:Configuration={1}", tscbTarget.Text, tscbConfiguration.Text), tsbtnShowPrompt.Checked));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = string.Format(CultureInfo.InvariantCulture, Title, FileName, Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\LeXtudio\MSBuildLaunchPad\MainForm");
            if (key == null)
            {
                return;
            }

            key.SetValue("Target", tscbTarget.Text);
            key.SetValue("Configuration", tscbConfiguration.Text);
            key.SetValue("AutoHide", tsbtnAutoHide.Checked.ToString());
            key.SetValue("ShowPrompt", tsbtnShowPrompt.Checked.ToString());
        }
    }
}
