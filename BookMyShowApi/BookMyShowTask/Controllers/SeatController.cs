using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;


namespace BookMyShowTask.Controllers
{
    [Route("api/seat")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService SeatService;
        public SeatController(ISeatService seat)
        {

            SeatService = seat;
        }
        [HttpGet("")]
        public IEnumerable<Seat> GetSeats()
        {
            return SeatService.GetSeats();
        }
        [HttpGet("{id}")]
        public Seat GetSeat(int id)
        {
            return SeatService.GetSeat(id);
        }
        [HttpPost("")]
        public Seat AddSeat(Seat seat)
        {
            return SeatService.AddSeat(seat);
        }
        [HttpPut("{id}")]
        public Seat EditSeat(int id, Seat seat)
        {
            return SeatService.UpdateSeat(id, seat);
        }
        [HttpDelete("{id}")]
        public Seat DeleteSeat(int id)
        {
            return SeatService.DeleteSeat(id);
        }
    }
}
