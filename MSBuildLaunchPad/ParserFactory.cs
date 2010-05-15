using System.IO;

namespace MSBuildLaunchPad
{
    public static class ParserFactory
    {
        public static IParser Parse(string fileName)
        {
            if (Path.GetExtension(fileName) == ".sln")
            {
                return new SolutionParser(fileName);
            }

            if (Path.GetExtension(fileName) == ".csproj")
            {
                return new MSBuildScriptParser(fileName);
            }

            return null;
        }
    }
}