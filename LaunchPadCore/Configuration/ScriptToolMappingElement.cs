using System.Configuration;

namespace Lextm.MSBuildLaunchPad.Configuration
{
    public class ScriptToolMappingElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the Name setting.
        /// </summary>
        [ConfigurationProperty("scriptToolVersion", IsRequired = true, IsKey = true)]
        [StringValidator]
        public string ScriptToolVersion
        {
            get { return (string)base["scriptToolVersion"]; }
        }

        /// <summary>
        /// Gets the tool version setting.
        /// </summary>
        [ConfigurationProperty("tool", IsRequired = true)]
        [StringValidator]
        public string Tool
        {
            get { return (string)base["tool"]; }
        }
    }
}