using System.Configuration;

namespace Lextm.MSBuildLaunchPad.Configuration
{
    [ConfigurationCollection(typeof(SolutionFileMappingElement),
        CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class SolutionFileMappingElementCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
 
        public SolutionFileMappingElement this[int index]
        {
            get { return (SolutionFileMappingElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                base.BaseAdd(index, value);
            }
        }

        public new SolutionFileMappingElement this[string name]
        {
            get
            {
                var exact = (SolutionFileMappingElement)BaseGet(name);
                if (exact == null)
                {
                    var parts = name.Split('|');
                    foreach (SolutionFileMappingElement item in this)
                    {
                        if (item.SolutionFileVersion == parts[0] + "|*")
                        {
                            return item;
                        }
                    }

                    foreach (SolutionFileMappingElement item in this)
                    {
                        if (item.SolutionFileVersion == "*|*")
                        {
                            return item;
                        }
                    }
                }

                return exact;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SolutionFileMappingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SolutionFileMappingElement)element).SolutionFileVersion;
        }
    }
}
