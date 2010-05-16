using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lextm.MSBuildLaunchPad
{
    public class SolutionParser: IParser
    {
        private static readonly Regex Regex = new Regex(
            "Microsoft\\sVisual\\sStudio\\sSolution\\sFile,\\sFormat\\sVe" +
            "rsion\\s(\\d*).00",
            RegexOptions.CultureInvariant
            | RegexOptions.Compiled
            );

        private readonly int _version;

        internal SolutionParser(string fileName)
        {
            string content = File.ReadAllText(fileName);
            Match match = Regex.Match(content);
            if (match == null)
            {
                throw new ArgumentException("this is not a sln file", "fileName");
            }

            int slnVersion = int.Parse(match.Groups[1].Value);
            switch (slnVersion)
            {
                case 11:
                    _version = 2;
                    break;
                case 10:
                    _version = 1;
                    break;
                case 9:
                    _version = 0;
                    break;
                default:
                    throw new ArgumentException("this file is not a sln file we support", "fileName");
            }
        }

        public int Version
        {
            get { return _version; }
        }
    }
}