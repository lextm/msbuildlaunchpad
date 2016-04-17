using System.IO;

namespace Lextm.MSBuildLaunchPad
{
    public class ToolPathValidator : IToolPathValidator
    {
        public bool Validate(Tool tool)
        {
            return File.Exists(tool.Path); 
        }
    }
}
