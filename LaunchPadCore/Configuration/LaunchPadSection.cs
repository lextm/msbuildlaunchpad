using System.Configuration;

namespace Lextm.MSBuildLaunchPad.Configuration
{
    public class LaunchPadSection : ConfigurationSection
    {
        [ConfigurationProperty("solutionFileMappings", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(SolutionFileMappingElement),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public SolutionFileMappingElementCollection SolutionFileMappings
        {
            get { return (SolutionFileMappingElementCollection)base["solutionFileMappings"]; }
        }

        [ConfigurationProperty("scriptToolMappings", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ScriptToolMappingElement),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ScriptToolMappingElementCollection ScriptToolMappings
        {
            get { return (ScriptToolMappingElementCollection)base["scriptToolMappings"]; }
        }

        private static LaunchPadSection section;

        public static LaunchPadSection GetSection()
        {
            if (section == null)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                return section = (LaunchPadSection) config.GetSection("launchPad");
            }

            return section;
        }
    }
}
