using System;

namespace Lextm.MSBuildLaunchPad
{
    public class Tool : IComparable<Tool>
    {
        public string Version { get; }
        public string Path { get; }
        private Version ActualVersion { get; }

        public Tool(string version, string path)
        {
            Path = System.IO.Path.Combine(path, "MSBuild.exe");
            Version = version;
            ActualVersion = new Version(version);
        }

        public const string Tool20Version = "2.0";
        public const string Tool35Version = "3.5";
        public const string Tool40Version = "4.0";
        public const string Tool120Version = "12.0";
        public const string Tool140Version = "14.0";

        public int CompareTo(Tool other)
        {
            return ActualVersion.CompareTo(other.ActualVersion);
        }
    }
}
