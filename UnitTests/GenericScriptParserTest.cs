using System.IO;
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
            Assert.AreEqual(Tool.Tool20Version, parser.Version);
            Assert.AreEqual(6, parser.Targets.Count);
        }

        [Test]
        public void TestProjImport()
        {
            var tempPathName = Path.GetTempPath() + Path.GetRandomFileName();
            Directory.CreateDirectory(tempPathName);
            Directory.CreateDirectory(tempPathName + @"\build");

            var projFileName = tempPathName + @"\import.proj";
            var targetsFileName = tempPathName + @"\build\import.targets";
            File.WriteAllBytes(projFileName, Properties.Resources.import);
            File.WriteAllBytes(targetsFileName, Properties.Resources.importtargets);

            var parser = new GenericScriptParser(projFileName);
            Assert.AreEqual(Tool.Tool20Version, parser.Version);
            Assert.AreEqual(6, parser.Targets.Count);
        }
    }
}
