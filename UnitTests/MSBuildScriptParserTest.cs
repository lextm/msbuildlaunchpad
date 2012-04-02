using System.IO;
using Lextm.MSBuildLaunchPad.Configuration;
using NUnit.Framework;

namespace Lextm.MSBuildLaunchPad.UnitTests
{
    [TestFixture]
    public class MSBuildScriptParserTest
    {
        [Test]
        public void TestVs2005Csproj()
        {
            string content = Properties.Resources.DomainModel;
            string tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, content);
            var parser = new MSBuildScriptParser(tempFileName);
            Assert.AreEqual(ToolElement.Tool20Version, parser.Version);
        }

        [Test]
        public void TestVs2008Csproj()
        {
            string content = Properties.Resources.ExpertManager;
            string tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, content);
            var parser = new MSBuildScriptParser(tempFileName);
            Assert.AreEqual(ToolElement.Tool35Version, parser.Version);
        }

        [Test]
        public void TestVs2010Csproj()
        {
            string content = Properties.Resources.SharpSnmpLib;
            string tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, content);
            var parser = new MSBuildScriptParser(tempFileName);
            Assert.AreEqual(ToolElement.Tool40Version, parser.Version);
        }
    }
}
