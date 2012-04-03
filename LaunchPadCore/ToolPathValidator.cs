using System.IO;
using Lextm.MSBuildLaunchPad.Configuration;

namespace Lextm.MSBuildLaunchPad
{
    public class ToolPathValidator : IToolPathValidator
    {
        public bool Validate(ToolElement tool)
        {
            return File.Exists(tool.Path); 
        }
    }
}