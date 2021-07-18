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
    class DemeritPointsTests
    {
        public DemeritPointsCalculator _demeritPtsCalc { get; set; }
        [SetUp]
        public void Setup()
        {
            _demeritPtsCalc = new DemeritPointsCalculator();
        }
        [Test]
        [TestCase(-20)]
        [TestCase(500)]
        [Ignore("It throws an exception and slows down the execution time")]
        public void CalculateDemeritPoints_WhenSpeedIsOutOfRange_RaiseAnException(int speed)
        {
            Assert.That(() => _demeritPtsCalc.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(64)]
        [TestCase(65)]
        [TestCase(66)]
        public void CalculateDemeritPoints_WhenSpeedIsLessThanTheLimit_ReturnZero(int speed)
        {
            var result = _demeritPtsCalc.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_WhenSpeeDIsAboveLimit_ReturnDemeritPoints()
        {

            var result = _demeritPtsCalc.CalculateDemeritPoints(100);
            Assert.That(result, Is.EqualTo(7));
        }
    }
}
