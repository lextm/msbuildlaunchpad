namespace Lextm.MSBuildLaunchPad
{
    internal class OptionSet
    {
        public string Name { get; set; }
        public string Arguments { get; set; }

        public OptionSet(string name, string arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}