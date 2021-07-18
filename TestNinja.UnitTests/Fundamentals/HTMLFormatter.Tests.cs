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
    class HTMLFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ReturnsAStrongHtmlTagWithContent()
        {
            //Arrange
            var formatter = new HtmlFormatter();

            //Act
            var result = formatter.FormatAsBold("test");

            //Assert (not too specific/General)
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("test"));
        }
    }
}
