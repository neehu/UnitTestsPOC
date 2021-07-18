using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
 [TestFixture]
    class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader { get; set; }
        private VideoService _service { get; set; }
        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
           _service = new VideoService(_fileReader.Object);
        }
        [Test]
        public void ReadAllText_WhenCalled_Error()
        {
            _fileReader.Setup(fr => fr.ReadAllText("video.txt")).Returns("");

            var result = _service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
