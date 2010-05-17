using System;
using System.Collections.Generic;
using System.Xml;

namespace Lextm.MSBuildLaunchPad
{
    public class GenericScriptParser : IParser
    {
        private readonly int _version;
        private readonly IList<string> _list = new List<string>();

        public GenericScriptParser(string fileName)
        {
            XmlDocument file = new XmlDocument();
            file.Load(fileName);
            if (file.DocumentElement == null || file.DocumentElement.Name != "Project")
            {
                throw new ArgumentException("this is not a proj file", "fileName");
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
                throw new ArgumentException("this is not a proj file", "fileName");
            }

            foreach (XmlNode node in file.DocumentElement.ChildNodes)
            {
                if (node.Name == "Target")
                {
                    XmlAttribute name = node.Attributes["Name"];
                    if (name == null)
                    {
                        continue;
                    }

                    _list.Add(name.Value);
                }
            }
        }

        public int Version
        {
            get { return _version; }
        }

        public ICollection<string> Targets
        {
            get { return _list; }
        }
    }
}