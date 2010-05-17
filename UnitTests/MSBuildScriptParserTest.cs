using System.IO;
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
            Assert.AreEqual(0, parser.Version);
        }

        [Test]
        public void TestVs2008Csproj()
        {
            string content = Properties.Resources.ExpertManager;
            string tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, content);
            var parser = new MSBuildScriptParser(tempFileName);
            Assert.AreEqual(1, parser.Version);
        }

        [Test]
        public void TestVs2010Csproj()
        {
            string content = Properties.Resources.SharpSnmpLib;
            string tempFileName = Path.GetTempFileName();
            File.WriteAllText(tempFileName, content);
            var parser = new MSBuildScriptParser(tempFileName);
            Assert.AreEqual(2, parser.Version);
        }
    }
}
