using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mock
{

    [TestFixture]
   public class InstallerHelperTests
    {
        private Mock<IClientRepository> _client { get; set; }
        private InstallerHelper _installer { get; set; }
        [SetUp]
        public void Setup()
        {
            _client = new Mock<IClientRepository>();
             _installer = new InstallerHelper(_client.Object);
        }
        [Test]
        public void DownloadInstaller_WhenNoExceptionOccurs_ReturnTrue()
        {
            _client.Setup(installer => installer.getDownloadedFile(It.IsAny<string>(), It.IsAny<string>()));

            var result = _installer.DownloadInstaller("", "");

            Assert.That(result, Is.EqualTo(true));

        }

        [Test]
        public void DownloadInstaller_WhenAnExceptionOccurs_ReturnFalse()
        {
            _client.Setup(isa => isa.getDownloadedFile(It.IsAny<string>(),It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installer.DownloadInstaller("customername", "installer");

            Assert.That(result, Is.False);
        }
    }
}
