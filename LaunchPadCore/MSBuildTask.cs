using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Lextm.MSBuildLaunchPad
{
    public class MSBuildTask
    {
        private readonly string _fileName;
        private readonly string _dotNetVersion;
        private readonly string _configuration;
        private readonly bool _showPrompt;

        public MSBuildTask(string fileName, string dotNetVersion, string task, bool showPrompt)
        {
            _fileName = fileName;
            _dotNetVersion = dotNetVersion;
            _configuration = task;
            _showPrompt = showPrompt;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public void Execute()
        {
            string msBuildPath = FindMSBuildPath(_dotNetVersion);
            if (msBuildPath == null)
            {
                return;
            }

            Process p = new Process
            {
                StartInfo =
                {
                    FileName = msBuildPath,
                    WorkingDirectory = Path.GetDirectoryName(_fileName),
                    Arguments =
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "\"{0}\" {1} /l:MSBuildErrorListLogger,\"{2}\\MSBuildShellExtension.dll\"",
                            _fileName,
                            _configuration,
                            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)),
                    WindowStyle = _showPrompt ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden
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
                    next = null;
                }
                else
                {
                    // no msbuild found.
                    return null;
                }
            } 
            while (!File.Exists(current));

            return current;
        }
    }
}
