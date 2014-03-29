using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Lextm.MSBuildLaunchPad.Configuration;
using Microsoft.Win32;

namespace Lextm.MSBuildLaunchPad
{
    internal partial class Form1 : Form
    {
        private string FileName { get; set; }

        private const string Title = "MSBuild Launch Pad - {0}";
        private const string TitleAdmin = "MSBuild Launch Pad (Administrator) - {0}";
        private const string About = "About MSBuild Launch Pad (Version: {0})";
        private const string PadKey = @"Software\LeXtudio\MSBuildLaunchPad\MainForm";

        public Form1(string fileName)
        {
            FileName = fileName;
            InitializeComponent();
             
            foreach (ToolElement tool in LaunchPadSection.GetSection().Tools)
            {
                tscbVersion.Items.Add(tool.Version);
            }

            IParser parser = null;
            try
            {
                parser = ParserFactory.Parse(fileName);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred and the project file cannot be parsed");
                Environment.Exit(-1);
            }

            tscbVersion.SelectedIndex = LaunchPadSection.GetSection().Tools.GetIndexOf(parser.Version);
            foreach (var target in parser.Targets)
            {
                tscbTarget.Items.Add(target);
            }

            // Restore settings
            RegistryKey options = Registry.CurrentUser.OpenSubKey(PadKey);
            if (options == null)
            {
                return;
            }

            tscbTarget.Text = options.GetValue("Target", "Build").ToString();
            tscbConfiguration.Text = options.GetValue("Configuration", "Debug").ToString();
            tscbPlatform.Text = options.GetValue("Platform", "(empty)").ToString();
            tsbtnAutoHide.Checked = Convert.ToBoolean(options.GetValue("AutoHide", "False"), CultureInfo.InvariantCulture);
            tsbtnShowPrompt.Checked = Convert.ToBoolean(options.GetValue("ShowPrompt", "True"), CultureInfo.InvariantCulture);
            
            // Find MSBuild Shell Extension settings.
            RegistryKey editor = Registry.CurrentUser.OpenSubKey(@"Software\Ardal\MSBuildShellExtension\Editors\Notepad");
            if (editor != null)
            {
                return;
            }
            
            // Fill in editor registry keys for MSBuild Shell Extension if it was not installed.
            editor = Registry.CurrentUser.CreateSubKey(@"Software\Ardal\MSBuildShellExtension\Editors\Notepad");
            if (editor == null)
            {
                return;
            }

            editor.SetValue("Arguments", "{file}");
            editor.SetValue("DefaultEditor", "True");
            editor.SetValue("Filename", "notepad.exe");
        }

        private void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
        {
            var task = (MSBuildTask)e.Argument;
            task.Execute();
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
            if (string.IsNullOrEmpty(tscbPlatform.Text))
            {
                tscbPlatform.Text = "(empty)";
            }

            tspbProgress.Style = ProgressBarStyle.Marquee;
            tspbProgress.MarqueeAnimationSpeed = 30; 
            backgroundWorker1.RunWorkerAsync(new MSBuildTask(FileName, tscbVersion.Text, MSBuildTask.GenerateArgument(tscbTarget.Text, tscbConfiguration.Text, tscbPlatform.Text), tsbtnShowPrompt.Checked));
        }

        private void Form1Load(object sender, EventArgs e)
        {
            Text = string.Format(CultureInfo.InvariantCulture, UacHelper.IsProcessElevated ? TitleAdmin : Title, Path.GetFileName(FileName));
            tsbtnAbout.ToolTipText = string.Format(CultureInfo.InvariantCulture, About,
                                                   Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void Form1FormClosing(object sender, FormClosingEventArgs e)
        {
            // save settings
            RegistryKey key = Registry.CurrentUser.CreateSubKey(PadKey);
            if (key == null)
            {
                return;
            }

            key.SetValue("Target", tscbTarget.Text);
            key.SetValue("Configuration", tscbConfiguration.Text);
            key.SetValue("Platform", tscbPlatform.Text);
            key.SetValue("AutoHide", tsbtnAutoHide.Checked.ToString());
            key.SetValue("ShowPrompt", tsbtnShowPrompt.Checked.ToString());
        }

        private void TsbtnAboutClick(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "http://msbuildlaunchpad.codeplex.com");
        }
    }
}
