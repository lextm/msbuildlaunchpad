using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;

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

        public void Execute()
        {
            string msbuild = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), string.Format(CultureInfo.InvariantCulture, @"..\Microsoft.NET\Framework\{0}\MSBuild.exe", _dotNetVersion));
            Process p = new Process
                            {
                                StartInfo =
                                    {
                                        FileName = msbuild,
                                        WorkingDirectory = Path.GetDirectoryName(_fileName),
                                        Arguments =
                                            string.Format(CultureInfo.InvariantCulture,
                                                          "\"{0}\" {1} /l:MSBuildErrorListLogger,\"{2}\\MSBuildShellExtension.dll\"",
                                                          _fileName, _configuration,
                                                          Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)),
                                        WindowStyle = ProcessWindowStyle.Hidden
                                    }
                            };
            p.Start();
            p.WaitForExit();
        }
    }
}
