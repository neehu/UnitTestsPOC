using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingRepository> _bookingRepo { get; set; }
        private Booking existingBooking { get; set; }

       
        [SetUp]
        public void Setup()
        {
            _bookingRepo = new Mock<IBookingRepository>();
            existingBooking = new Booking { ArrivalDate = DateTime.Now, 
                                            DepartureDate = DateTime.Now.AddDays(2), 
                                            Id = 1, Reference = It.IsAny<string>() };
        }
        [Test]
        public void OverlappingBookingsExist_WhenBookingStatusIsCancelled_ReturnEmptyString()
        {
            existingBooking.Status = "Cancelled";

            var result = BookingHelper.OverlappingBookingsExist(existingBooking, _bookingRepo.Object);


            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingExist_WhenBookingStatusIsNotCancelled_CheckIfCancelledBookingMethodIsCalled()
        {
            BookingHelper.OverlappingBookingsExist(existingBooking,_bookingRepo.Object);

            _bookingRepo.Verify(br => br.getActiveBookings(existingBooking.Id));
        }



        [Test]
        public void OverlappingBookingExist_WhenNoOverlappingBookingExists_ReturnEmptyString()
        {
            var activeBookings = new List<Booking> { new Booking { ArrivalDate = DateTime.Now.AddDays(-3),
                DepartureDate = DateTime.Now.AddDays(-4), Id = 2, Reference = "test" } }.AsQueryable();


            _bookingRepo.Setup(br => br.getActiveBookings(existingBooking.Id))
                        .Returns(activeBookings);

            var result = BookingHelper.OverlappingBookingsExist(existingBooking,_bookingRepo.Object);

            Assert.That(result, Is.EqualTo(string.Empty));

        }

        [Test]
        public void OverlappingBookingExist_WhenOverlappingBookingExists_ReturnBookingReference()
        {
            var activeBookings = new List<Booking> { new Booking { ArrivalDate = DateTime.Now.AddDays(-1), DepartureDate = DateTime.Now.AddDays(2), Id = 2, Reference = "test" } }
                                .AsQueryable();
            _bookingRepo.Setup(br => br.getActiveBookings(existingBooking.Id))
                        .Returns(activeBookings);

            var result = BookingHelper.OverlappingBookingsExist(existingBooking,_bookingRepo.Object);

            Assert.That(result, Is.EqualTo("test"));
        }

    }
}
