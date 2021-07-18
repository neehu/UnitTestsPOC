using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var user = new User() { IsAdmin = true };
            var reservation = new Reservation();
            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.That(result,Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserIsMadeBy_True()
        {

            //Arrange
            var user = new User() { IsAdmin = false };
            var reservation = new Reservation { MadeBy = user };
            //Act
           var result = reservation.CanBeCancelledBy(user);
            //Assert
            Assert.That(result,Is.True);
        }

        [Test]
        public void CanBeCAncelledBy_UserIsDifferent_False()
        {
            //Arrange
            var user = new User() { IsAdmin = false };
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.That(result,Is.False);
        }
    }
}
