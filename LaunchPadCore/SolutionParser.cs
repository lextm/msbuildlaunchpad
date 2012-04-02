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

        private readonly string _version;

        public SolutionParser(string fileName)
        {
            string content = File.ReadAllText(fileName);
            Match match = Regex.Match(content);
            if (match == null)
            {
                throw new ArgumentException("this is not a sln file", "fileName");
            }


            var toolVersion = LaunchPadSection.GetSection().SolutionFileMappings[match.Groups[1].Value];
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