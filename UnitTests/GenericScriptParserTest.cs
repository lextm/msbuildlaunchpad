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
            Assert.AreEqual(0, parser.Version);
            Assert.AreEqual(6, parser.Targets.Count);
        }
    }
}
