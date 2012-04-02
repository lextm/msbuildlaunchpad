using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Lextm.MSBuildLaunchPad.Configuration;

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

        [SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public void Execute()
        {
            string msBuildPath = FindMSBuildPath(_dotNetVersion);
            if (msBuildPath == null)
            {
                return;
            }

            var p = new Process
            {
                StartInfo =
                {
                    FileName = msBuildPath,
                    WorkingDirectory = Path.GetDirectoryName(_fileName),
                    Arguments =
                        String.Format(
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
                    String.Format(CultureInfo.InvariantCulture, @"..\Microsoft.NET\Framework\v{0}\MSBuild.exe", next));

                // If the exact match version is not installed, switch to a newer version.
                if (version == ToolElement.Tool20Version)
                {
                    // TODO: in theory, this should never hit.
                    next = ToolElement.Tool35Version;
                }
                else if (version == ToolElement.Tool35Version)
                {
                    next = ToolElement.Tool40Version;
                }
                else if (version == ToolElement.Tool40Version)
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

        public static string GenerateArgument(string target, string configuration, string platform)
        {
            var result = new StringBuilder();
            result.AppendFormat(CultureInfo.InvariantCulture, @"/t:{0} /p:Configuration={1}", target, configuration);
            if (platform != "(empty)")
            {
                result.AppendFormat(CultureInfo.InvariantCulture, @" /p:Platform={0}", platform);
            }

            return result.ToString();
        }
    }
}
