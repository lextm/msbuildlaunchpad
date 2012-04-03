using Lextm.MSBuildLaunchPad.Configuration;

namespace Lextm.MSBuildLaunchPad
{
    public interface IToolPathValidator
    {
        bool Validate(ToolElement tool);
    }
}