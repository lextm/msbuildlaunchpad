using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Lextm.MSBuildLaunchPad
{
    internal class MSBuildTask
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
            Process p = new Process
            {
                StartInfo =
                {
                    FileName = FindMSBuildPath(_dotNetVersion),
                    WorkingDirectory = Path.GetDirectoryName(_fileName),
                    Arguments =
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "\"{0}\" {1} /l:MSBuildErrorListLogger,\"{2}\\MSBuildShellExtension.dll\"",
                            _fileName,
                            _configuration,
                            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)),
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            p.Start();
            p.WaitForExit();
        }

        private static string FindMSBuildPath(string version)
        {
            string next = version;
            string current;
            do
            {
                current = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.System),
                    string.Format(CultureInfo.InvariantCulture, @"..\Microsoft.NET\Framework\{0}\MSBuild.exe", next));

                // If the exact match version is not installed, switch to a newer version.
                if (version == "v2.0.50727")
                {
                    // TODO: in theory, this should never hit.
                    next = "v3.5";
                }
                else if (version == "v3.5")
                {
                    next = "v4.0.30319";
                }
                else if (version == "v4.0.30319")
                {
                    throw new ArgumentException("No newer MSBuild version.", "version");
                }
                else
                {
                    throw new ArgumentException("No newer MSBuild version.", "version");
                }
            } 
            while (!File.Exists(current));

            return current;
        }
    }
}
