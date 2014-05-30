using System.Configuration;

namespace Lextm.MSBuildLaunchPad.Configuration
{
    [ConfigurationCollection(typeof(ScriptToolMappingElement),
        CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class ScriptToolMappingElementCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public ScriptToolMappingElement this[int index]
        {
            get { return (ScriptToolMappingElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                base.BaseAdd(index, value);
            }
        }

        public new ScriptToolMappingElement this[string name]
        {
            get
            {
                var exact = (ScriptToolMappingElement)BaseGet(name);
                if (exact == null)
                {
                    foreach (ScriptToolMappingElement item in this)
                    {
                        if (item.ScriptToolVersion == "*")
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
            return new ScriptToolMappingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ScriptToolMappingElement)element).ScriptToolVersion;
        }
    }
}