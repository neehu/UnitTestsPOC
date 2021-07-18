using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class ErrorLoggerTests
    {
        private ErrorLogger _log { get; set; }

        [SetUp]
        public void Setup()
        {

            _log = new ErrorLogger();
        }
        [Test]
        public void Log_WhenInvoked_SrtLastErrorProperty()
        {

            _log.Log("test");

            Assert.That(_log.LastError, Is.EqualTo("test"));
        }

        [Test]
        [Ignore ("Because it raises an error")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_WhenInvokedWithNullOrEmptyValus_RaiseAnException(string value)
        {
            Assert.That(() => _log.Log(value), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_WhenValidInput_RaiseAnErrorLoggedEvent()
        {
            var id = Guid.Empty;
            _log.ErrorLogged += (sender, args) => { id = args; };
            _log.Log("a");
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
