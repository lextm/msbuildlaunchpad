using System.Configuration;

namespace Lextm.MSBuildLaunchPad.Configuration
{
    public class ToolElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the Version setting.
        /// </summary>
        [ConfigurationProperty("version", IsRequired = true, IsKey = true)]
        [StringValidator]
        public string Version
        {
            get { return (string)base["version"]; }
        }

        public const string Tool20Version = "2.0.50727";
        public const string Tool35Version = "3.5";
        public const string Tool40Version = "4.0.30319";
    }
}