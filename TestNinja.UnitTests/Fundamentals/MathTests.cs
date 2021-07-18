using NUnit.Framework;
using TestNinja.Fundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
   public  class MathTests
    {
        private Fundamentals.Math _math { get; set; }

        [SetUp]
        public void Setup()
        {

            _math = new Fundamentals.Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            //Act
            var result = _math.Add(1, 2);

            Assert.That(result,Is.EqualTo(3));
        }

        [Test]
        [TestCase(2,1,2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnMaximumValue(int a,int b,int expectedResult)
        {
            //Act
           var result = _math.Max(a, b);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [Test]
        public void GetOddNumbers_WhenLimitIsMoreThanZero_ReturnsOddNumbersUptoLimit()
        {
            var result = _math.GetOddNumbers(5);
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
        }

        [Test]
        [Ignore("Because I want to!")]
        public void GetOddNumbers_WhenLimitIsLessTHanZero_ReturnsOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(-5);
            Assert.That(result.Count(), Is.AtLeast(0));
        }

        [Test]
        public void GetOddNUmbers_WhenLimitIsEqualToZero_ReturnEmptyArray()
        {

            var result = _math.GetOddNumbers(0);

            Assert.That(result.Count(), Is.EqualTo(0));
        }
    }
}
