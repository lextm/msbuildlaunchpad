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
            var file = OpenFile(fileName);

            _version = ParseVersion(file);

            foreach (var target in ParseTargets(file))
            {
                _list.Add(target);
            }
        }

        private static XmlDocument OpenFile(string fileName)
        {
            var file = new XmlDocument();
            file.Load(fileName);
            if (file.DocumentElement == null || file.DocumentElement.Name != "Project")
            {
                throw new ArgumentException("this is not a proj file", "fileName");
            }

            return file;
        }

        private static string ParseVersion(XmlDocument file)
        {
            string attribute = file.DocumentElement.GetAttribute("ToolsVersion");
            if (string.IsNullOrEmpty(attribute))
            {
                return Tool.Tool20Version;
            }
            else
            {
                var element = LaunchPadSection.GetSection().ScriptToolMappings[attribute];
                if (element == null)
                {
                    throw new ArgumentException("this is not a proj file", "fileName");
                }

                return element.Tool;
            }
        }

        private static IEnumerable<string> ParseTargets(XmlDocument file)
        {
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

                yield return name.Value;
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
