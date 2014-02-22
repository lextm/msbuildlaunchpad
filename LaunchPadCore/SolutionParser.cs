using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Lextm.MSBuildLaunchPad.Configuration;

namespace Lextm.MSBuildLaunchPad
{
    public class SolutionParser : IParser
    {
        private static readonly Regex Regex = new Regex(
            "Microsoft\\sVisual\\sStudio\\sSolution\\sFile,\\sFormat\\sVe" +
            "rsion\\s(\\d*).00",
            RegexOptions.CultureInvariant | RegexOptions.Compiled);
        private static readonly Regex VersionDetector = new Regex(
            "VisualStudioVersion\\s*=\\s*(?<version>(\\d+)(\\.(\\d+))*)",
            RegexOptions.CultureInvariant | RegexOptions.Compiled);

        private readonly string _version;

        public SolutionParser(string fileName)
        {
            string content = File.ReadAllText(fileName);
            Match match = Regex.Match(content);
            if (!match.Success)
            {
                throw new ArgumentException("this is not a sln file", "fileName");
            }

            var fileVersion = match.Groups[1].Value;
            var versionFound = VersionDetector.Match(content);

            var key = string.Format("{0}|{1}", fileVersion, versionFound.Success ? versionFound.Groups["version"].Value : "*");
            var toolVersion = LaunchPadSection.GetSection().SolutionFileMappings[key];
            if (toolVersion == null)
            {
                throw new ArgumentException("this file is not a sln file we support", "fileName");
            }

            _version = toolVersion.Tool;
        }

        public string Version
        {
            get { return _version; }
        }

        public ICollection<string> Targets
        {
            get { return new[] { "Build", "Rebuild", "Clean" }; }
        }
    }
}