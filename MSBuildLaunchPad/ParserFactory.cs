using System.IO;

namespace MSBuildLaunchPad
{
    public static class ParserFactory
    {
        public static IParser Parse(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (extension == ".sln")
            {
                return new SolutionParser(fileName);
            }

            if (extension == ".csproj" || extension == ".vbproj")
            {
                return new MSBuildScriptParser(fileName);
            }

            return null;
        }
    }
}