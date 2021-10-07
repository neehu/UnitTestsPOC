using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mock
{
    [TestFixture]
    class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader { get; set; }
        private VideoService _service { get; set; }
        private Mock<IVideoContext> _context { get; set; }
        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _context = new Mock<IVideoContext>();
            _service = new VideoService(_fileReader.Object, _context.Object);
        }
        [Test]
        public void ReadAllText_WhenCalled_Error()
        {
            _fileReader.Setup(fr => fr.ReadAllText("video.txt")).Returns("");

            var result = _service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenCalledWithAListOfVideos_ReturnAStringOfIDs()
        {
            {
                _context.Setup(vs => vs.getUnProcessedVideos()).Returns(new List<Video>
                {
                    new Video { Id = 1},
                    new Video { Id = 2}
                });

                var result = _service.GetUnprocessedVideosAsCsv();

                Assert.That(result, Is.EqualTo("1,2"));
            }
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenCalledWithAnEmptyListOfVideos_ReturnAnEmptyString()
        {
            _context.Setup(vs => vs.getUnProcessedVideos()).Returns(new List<Video> { });

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }
    }
}
