using System.Collections.Generic;
using Lextm.MSBuildLaunchPad.Configuration;
using Moq;
using NUnit.Framework;

namespace Lextm.MSBuildLaunchPad.UnitTests
{
    [TestFixture]
    public class MSBuildTaskTestFixture
    {
        private ToolElement DotNet20
        {
            get { return LaunchPadSection.GetSection().Tools[0]; }
        }

        private ToolElement DotNet35
        {
            get { return LaunchPadSection.GetSection().Tools[1]; }
        }

        private ToolElement DotNet40
        {
            get { return LaunchPadSection.GetSection().Tools[2]; }
        }

        [Test]
        public void TestGetTool_20File_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // only .NET 4 or .NET 4.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(true);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet40.Path, task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // only .NET 4 or .NET 4.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(true);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet40.Path, task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // only .NET 4 or .NET 4.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(true);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet40.Path, task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_20File_20Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // only .NET 2 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(false);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet20.Path, task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_20Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // only .NET 2 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(false);
            task.Validator = mock.Object;

            Assert.AreEqual(null, task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_20Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // only .NET 2 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(false);
            task.Validator = mock.Object;

            Assert.AreEqual(null, task.FindMSBuildPath(ToolElement.Tool40Version));
        }

        [Test]
        public void TestGetTool_20File_20_35Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // .NET 3.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(false);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet20.Path, task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_20_35Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // .NET 3.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(false);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet35.Path, task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_20_35Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            
            // .NET 3.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(false);
            task.Validator = mock.Object;

            Assert.AreEqual(null, task.FindMSBuildPath(ToolElement.Tool40Version));
        }

        [Test]
        public void TestGetTool_20File_20_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // .NET 2 and 4/4.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(true);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet20.Path, task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_20_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            
            // .NET 2 and 4/4.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(true);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet40.Path, task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_20_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // .NET 2 and 4/4.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(false);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(true);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet40.Path, task.FindMSBuildPath(ToolElement.Tool40Version));
        }

        [Test]
        public void TestGetTool_20File_20_35_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // .NET 3.5 and 4/4.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(true);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet20.Path, task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_20_35_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // .NET 3.5 and 4/4.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(true);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet35.Path, task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_20_35_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();

            // .NET 3.5 and 4/4.5 is installed.
            mock.Setup(validator => validator.Validate(DotNet20)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet35)).Returns(true);
            mock.Setup(validator => validator.Validate(DotNet40)).Returns(true);
            task.Validator = mock.Object;

            Assert.AreEqual(DotNet40.Path, task.FindMSBuildPath(ToolElement.Tool40Version));
        }
    }
}
