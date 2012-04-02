using System.Configuration;

namespace Lextm.MSBuildLaunchPad.Configuration
{
    [ConfigurationCollection(typeof(ToolElement),
        CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class ToolElementCollection : ConfigurationElementCollection
    {
        public ToolElement this[int index]
        {
            get { return (ToolElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                base.BaseAdd(index, value);
            }
        }

        public new ToolElement this[string name]
        {
            get { return (ToolElement)BaseGet(name); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ToolElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ToolElement)element).Version;
        }

        public int GetIndexOf(string key)
        {
            return BaseIndexOf(BaseGet(key));
        }
    }
}