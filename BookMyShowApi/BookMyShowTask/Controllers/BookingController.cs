using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;

namespace BookMyShowTask.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService BookingService;
        public BookingController(IBookingService booking)
        {
            BookingService = booking;
        }
        [HttpGet("")]
        public IEnumerable<Booking> GetBookings()
        {
            return BookingService.GetBookings();
        }
        [HttpGet("{id}")]
        public Booking GetBooking(int id)
        {
            return BookingService.GetBooking(id);
        }
        [HttpPost("")]
        public Booking AddBooking(Booking booking)
        {
            return BookingService.AddBooking(booking);
        }
        [HttpPut("{id}")]
        public Booking EditBooking(int id, Booking booking)
        {
            return BookingService.UpdateBooking(id, booking);
        }
        [HttpDelete("{id}")]
        public Booking DeleteBooking(int id)
        {
            return BookingService.DeleteBooking(id);
        }
    }
}
