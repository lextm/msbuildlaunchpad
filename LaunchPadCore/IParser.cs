using System.Collections.Generic;

namespace Lextm.MSBuildLaunchPad
{
    public interface IParser
    {
        string Version { get; }
        
        ICollection<string> Targets { get; }
    }
}