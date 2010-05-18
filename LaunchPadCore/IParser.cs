using System.Collections.Generic;

namespace Lextm.MSBuildLaunchPad
{
    public interface IParser
    {
        int Version { get; }
        
        ICollection<string> Targets { get; }
    }
}