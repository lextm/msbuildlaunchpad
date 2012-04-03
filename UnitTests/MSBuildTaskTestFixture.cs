using System.Collections.Generic;
using Lextm.MSBuildLaunchPad.Configuration;
using Moq;
using NUnit.Framework;

namespace Lextm.MSBuildLaunchPad.UnitTests
{
    [TestFixture]
    public class MSBuildTaskTestFixture
    {
        [Test]
        public void TestGetTool_20File_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // only .NET 4 or .NET 4.5 is installed.
            var valids = new Queue<bool>(new[] {false, false, true});
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] {".net 4"});
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 4", task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // only .NET 4 or .NET 4.5 is installed.
            var valids = new Queue<bool>(new[] { false, true });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 4", task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // only .NET 4 or .NET 4.5 is installed.
            var valids = new Queue<bool>(new[] { true });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 4", task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_20File_20Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // only .NET 2 is installed.
            var valids = new Queue<bool>(new[] { true });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 2" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 2", task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_20Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // only .NET 2 is installed.
            var valids = new Queue<bool>(new[] { false, false });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 35", ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(null, task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_20Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // only .NET 2 is installed.
            var valids = new Queue<bool>(new[] { false });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(null, task.FindMSBuildPath(ToolElement.Tool40Version));
        }

        [Test]
        public void TestGetTool_20File_20_35Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // .NET 3.5 is installed.
            var valids = new Queue<bool>(new[] { true, true, false });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 2", ".net 35", ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 2", task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_20_35Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // .NET 3.5 is installed.
            var valids = new Queue<bool>(new[] { true, false });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 35", ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 35", task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_20_35Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // .NET 3.5 is installed.
            var valids = new Queue<bool>(new[] { false });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(null, task.FindMSBuildPath(ToolElement.Tool40Version));
        }

        [Test]
        public void TestGetTool_20File_20_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // .NET 2 and 4/4.5 is installed.
            var valids = new Queue<bool>(new[] { true, false, true });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 2", ".net 35", ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 2", task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_20_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // .NET 2 and 4/4.5 is installed.
            var valids = new Queue<bool>(new[] { true, false, true });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 4", task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_20_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // .NET 2 and 4/4.5 is installed.
            var valids = new Queue<bool>(new[] { true });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 4", task.FindMSBuildPath(ToolElement.Tool40Version));
        }

        [Test]
        public void TestGetTool_20File_20_35_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // .NET 3.5 and 4/4.5 is installed.
            var valids = new Queue<bool>(new[] { true, true, true });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 2", ".net 35", ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 2", task.FindMSBuildPath(ToolElement.Tool20Version));
        }

        [Test]
        public void TestGetTool_35File_20_35_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // .NET 3.5 and 4/4.5 is installed.
            var valids = new Queue<bool>(new[] { true, true });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 35", ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 35", task.FindMSBuildPath(ToolElement.Tool35Version));
        }

        [Test]
        public void TestGetTool_40File_20_35_40Tool()
        {
            var task = new MSBuildTask("test", ToolElement.Tool20Version, "test", true);
            var mock = new Mock<IToolPathValidator>();
            mock.SetupProperty(validator => validator.Version);

            // .NET 3.5 and 4/4.5 is installed.
            var valids = new Queue<bool>(new[] { true });
            mock.SetupGet(validator => validator.IsValid).Returns(valids.Dequeue);
            var paths = new Queue<string>(new[] { ".net 4" });
            mock.SetupGet(validator => validator.FullPath).Returns(paths.Dequeue);
            task.Validator = mock.Object;

            Assert.AreEqual(".net 4", task.FindMSBuildPath(ToolElement.Tool40Version));
        }
    }
}
