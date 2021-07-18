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
    class FizzBuzzTests
    {
        public FizzBuzz fizzBuzz { get; set; }
        [SetUp]
        public void SetUp()
        {
            fizzBuzz = new FizzBuzz();
        }


        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(6, "Fizz")]
        [TestCase(20, "Buzz")]
        [TestCase(8, "8")]
        public void GetOutput_WhenNumberIsDivisibleBy3OR5_ReturnFizzORBuzzORFizzBuzz(int a,string output)
        {
            var result = FizzBuzz.GetOutput(a);

            Assert.That(result, Is.EqualTo(output));
        }
    }
}
