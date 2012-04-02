using System.Configuration;

namespace Lextm.MSBuildLaunchPad.Configuration
{
    public class SolutionFileMappingElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the Name setting.
        /// </summary>
        [ConfigurationProperty("solutionFileVersion", IsRequired = true, IsKey = true)]
        [StringValidator]
        public string SolutionFileVersion
        {
            get { return (string)base["solutionFileVersion"]; }
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