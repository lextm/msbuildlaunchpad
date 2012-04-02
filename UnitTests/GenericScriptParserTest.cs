using System.IO;
using Lextm.MSBuildLaunchPad.Configuration;
using NUnit.Framework;

namespace Lextm.MSBuildLaunchPad.UnitTests
{
    [TestFixture]
    public class GenericScriptParserTest
    {
        [Test]
        public void TestProj()
        {
            byte[] bytes = Properties.Resources.build;
            string tempFileName = Path.GetTempFileName();
            File.WriteAllBytes(tempFileName, bytes);
            var parser = new GenericScriptParser(tempFileName);
            Assert.AreEqual(ToolElement.Tool20Version, parser.Version);
            Assert.AreEqual(6, parser.Targets.Count);
        }
    }
}
