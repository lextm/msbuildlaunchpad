using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace MSBuildLaunchPad
{
    class MSBuildTask
    {
        private readonly string _fileName;
        private readonly string _dotNetVersion;
        private readonly string _configuration;

        public MSBuildTask(string fileName, string dotNetVersion, string task)
        {
            _fileName = fileName;
            _dotNetVersion = dotNetVersion;
            _configuration = task;
        }

        public string[] Execute()
        {
            string msbuild = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), string.Format(CultureInfo.InvariantCulture, @"..\Microsoft.NET\Framework\{0}\MSBuild.exe", _dotNetVersion));
            Process p = new Process
                            {
                                StartInfo =
                                    {
                                        FileName = msbuild,
                                        WorkingDirectory = Path.GetDirectoryName(_fileName),
                                        Arguments =
                                            string.Format(CultureInfo.InvariantCulture, "\"{0}\" {1}", _fileName, _configuration),
                                        UseShellExecute = false,
                                        RedirectStandardOutput = false,
                                        RedirectStandardError = false
                                    }
                            };
            p.Start();
            string error = null; // p.StandardError.ReadToEnd();
            string output = null; //p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return new[] { error, output };
        }
    }
}