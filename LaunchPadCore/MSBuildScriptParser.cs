using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Lextm.MSBuildLaunchPad
{
    public class MSBuildScriptParser : IParser
    {
        private readonly int _version;

        public MSBuildScriptParser(string fileName)
        {
            XmlDocument file = new XmlDocument();
            file.Load(fileName);
            if (file.DocumentElement == null)
            {
                throw new ArgumentException("this is not a csproj/vbproj file", "fileName");
            }

            string attribute = file.DocumentElement.GetAttribute("ToolsVersion");
            if (string.IsNullOrEmpty(attribute))
            {
                _version = 0;
            }
            else if (attribute == "3.5")
            {
                _version = 1;
            }
            else if (attribute == "4.0")
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