using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookMyShowContext Context;
        public IMapper Mapper;
        public BookingService(BookMyShowContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public Booking AddBooking(Booking booking)
        {
            if (booking != null)
            {
                Context.Booking.Add(booking);
                Context.SaveChanges();
                return Mapper.Map<Booking>(booking);
            }
            return null;
        }

        public Booking DeleteBooking(int id)
        {
            var booking = Context.Booking.FirstOrDefault(x => x.ID == id);
            Context.Entry(booking).State = EntityState.Deleted;
            Context.SaveChanges();
            return Mapper.Map<Booking>(booking);
        }

        public Booking GetBooking(int id)
        {
            var booking = Context.Booking.FirstOrDefault(x => x.ID == id);
            return Mapper.Map<Booking>(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            var booking = Context.Booking.ToList();
            return Mapper.Map<IEnumerable<Booking>>(booking);
        }

        public Booking UpdateBooking(int id, Booking booking)
        {
            var bookingData = Context.Booking.Where(x => x.ID == id).FirstOrDefault();
            if (bookingData != null)
            {
                booking.ID = id;
                Context.Entry(bookingData).CurrentValues.SetValues(booking);
                Context.SaveChanges();
            }
            return Mapper.Map<Booking>(booking);
        }
    }
}
