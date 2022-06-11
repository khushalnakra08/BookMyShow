using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetBookings();
        Booking GetBooking(int id);
        Booking AddBooking(Booking booking);
        Booking UpdateBooking(int id, Booking booking);
        Booking DeleteBooking(int id);
    }
}
