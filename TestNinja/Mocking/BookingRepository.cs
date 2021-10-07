using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class BookingRepository : IBookingRepository
    {
        private UnitOfWork _unitOfWork { get; set; }

        public BookingRepository()  
        {
            _unitOfWork = new UnitOfWork();
        }
        public IQueryable<Booking> getActiveBookings(int? id )
        {
           var bookings = _unitOfWork.Query<Booking>()
                    .Where( b => b.Status != "Cancelled");

            if (id.HasValue)
            {
                bookings = bookings.Where(b => b.Id == id);
            }
            return bookings;
        }

    }
}
