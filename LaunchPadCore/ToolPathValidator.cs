using System;
using System.Globalization;
using System.IO;

namespace Lextm.MSBuildLaunchPad
{
    public class ToolPathValidator : IToolPathValidator
    {
        public string FullPath { get; set; }

        public bool IsValid
        {
            get { return File.Exists(FullPath); }
        }

        private string _version;
        public string Version
        {
            get
            {
                return _version;
            }

            set 
            { 
                _version = value;
                FullPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.System),
                    String.Format(CultureInfo.InvariantCulture, @"..\Microsoft.NET\Framework\v{0}\MSBuild.exe", _version));
            }
        }
    }
}