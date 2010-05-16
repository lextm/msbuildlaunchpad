using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lextm.MSBuildLaunchPad
{
    public class MSBuildScriptParser : IParser
    {
        private static Regex _regex = new Regex(
            "ToolsVersion=\"(\\d\\.\\d)\"",
            RegexOptions.CultureInvariant
            | RegexOptions.Compiled
            );

        private readonly int _version;

        public MSBuildScriptParser(string fileName)
        {
            string content = File.ReadAllText(fileName);
            Match match = _regex.Match(content);
            if (match == null)
            {
                throw new ArgumentException("this is not a csproj/vbproj file", "fileName");
            }

            string msbuildVersion = match.Groups[1].Value;
            if (msbuildVersion == "2.0")
            {
                _version = 0;
            }
            else if (msbuildVersion == "3.5")
            {
                _version = 1;
            }
            else if (msbuildVersion == "4.0")
            {
                _version = 2;
            }
            else
            {
                throw new ArgumentException("this is not a csproj/vbproj file", "fileName");
            }
        }

        public int Version
        {
            get { return _version; }
        }
    }
}