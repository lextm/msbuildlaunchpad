namespace Lextm.MSBuildLaunchPad
{
    public interface IToolPathValidator
    {
        string FullPath { get; set; }
        bool IsValid { get; }
        string Version { get; set; }
    }
}