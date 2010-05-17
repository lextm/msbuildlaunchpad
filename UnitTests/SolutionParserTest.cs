using System.IO;
using NUnit.Framework;

namespace Lextm.MSBuildLaunchPad.UnitTests
{
    [TestFixture]
    public class SolutionParserTest
    {
        [Test]
        public void TestVs2005Sln()
        {
            byte[] bytes = Properties.Resources.MSBuildShellExtension;
            string tempFileName = Path.GetTempFileName();
            File.WriteAllBytes(tempFileName, bytes);
            var parser = new SolutionParser(tempFileName);
            Assert.AreEqual(0, parser.Version);
        }

        [Test]
        public void TestVs2008Sln()
        {
            byte[] bytes = Properties.Resources.Lextm_CBC2_Full;
            string tempFileName = Path.GetTempFileName();
            File.WriteAllBytes(tempFileName, bytes);
            var parser = new SolutionParser(tempFileName);
            Assert.AreEqual(1, parser.Version);
        }

        [Test]
        public void TestVs2010Sln()
        {
            byte[] bytes = Properties.Resources.SharpSnmpLib1;
            string tempFileName = Path.GetTempFileName();
            File.WriteAllBytes(tempFileName, bytes);
            var parser = new SolutionParser(tempFileName);
            Assert.AreEqual(2, parser.Version);
        }
    }
}
