using System;
using System.Collections.Generic;
using System.Xml;
using Lextm.MSBuildLaunchPad.Configuration;

namespace Lextm.MSBuildLaunchPad
{
    public class GenericScriptParser : IParser
    {
        private readonly string _version;
        private readonly IList<string> _list = new List<string>();

        public GenericScriptParser(string fileName)
        {
            var file = new XmlDocument();
            file.Load(fileName);
            if (file.DocumentElement == null || file.DocumentElement.Name != "Project")
            {
                throw new ArgumentException("this is not a proj file", "fileName");
            }

            string attribute = file.DocumentElement.GetAttribute("ToolsVersion");
            if (string.IsNullOrEmpty(attribute))
            {
                _version = Tool.Tool20Version;
            }
            else
            {
                var element = LaunchPadSection.GetSection().ScriptToolMappings[attribute];
                if (element == null)
                {
                    throw new ArgumentException("this is not a proj file", "fileName");
                }

                _version = element.Tool;
            }

            foreach (XmlNode node in file.DocumentElement.ChildNodes)
            {
                if (node.Name != "Target")
                {
                    continue;
                }

                if (node.Attributes == null)
                {
                    continue;
                }

                XmlAttribute name = node.Attributes["Name"];
                if (name == null)
                {
                    continue;
                }

                _list.Add(name.Value);
            }
        }

        public string Version
        {
            get { return _version; }
        }

        public ICollection<string> Targets
        {
            get { return _list; }
        }
    }
}
