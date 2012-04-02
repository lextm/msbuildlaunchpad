using System;
using System.Collections.Generic;
using System.Xml;
using Lextm.MSBuildLaunchPad.Configuration;

namespace Lextm.MSBuildLaunchPad
{
    public class MSBuildScriptParser : IParser
    {
        private readonly string _version;

        public MSBuildScriptParser(string fileName)
        {
            var file = new XmlDocument();
            file.Load(fileName);
            if (file.DocumentElement == null || file.DocumentElement.Name != "Project")
            {
                throw new ArgumentException("this is not a csproj/vbproj file", "fileName");
            }

            string attribute = file.DocumentElement.GetAttribute("ToolsVersion");
            if (string.IsNullOrEmpty(attribute))
            {
                _version = ToolElement.Tool20Version;
            }
            else
            {
                var element = LaunchPadSection.GetSection().ScriptToolMappings[attribute];
                if (element == null)
                {
                    throw new ArgumentException("this is not a csproj/vbproj file", "fileName");
                }

                _version = element.Tool;
            }
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