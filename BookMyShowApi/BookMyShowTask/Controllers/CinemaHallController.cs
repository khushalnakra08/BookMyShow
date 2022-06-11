using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;


namespace BookMyShowTask.Controllers
{
    [Route("api/cinemaHall")]
    [ApiController]
    public class CinemaHallController : ControllerBase
    {
        private readonly ICinemaHallService CinemaHallService;
        public CinemaHallController(ICinemaHallService cinemaHall)
        {
            CinemaHallService = cinemaHall;
        }
        [HttpGet("")]
        public IEnumerable<CinemaHall> GetCinemaHalls()
        {
            return CinemaHallService.GetCinemaHalls();
        }
        [HttpGet("{id}")]
        public CinemaHall GetCinema(int id)
        {
            return CinemaHallService.GetCinemaHall(id);
        }
        [HttpGet("cinema/{id}")]
        public IEnumerable<CinemaHall> GetCinemaHallByCinemaId(int id) 
        {
            return CinemaHallService.GetCinemaHallByCinemaId(id);
        }
        [HttpPost("")]
        public CinemaHall AddCinemaHall(CinemaHall cinemaHall)
        {
            return CinemaHallService.AddCinemaHall(cinemaHall);
        }
        [HttpPut("{id}")]
        public CinemaHall EditCinemaHall(int id, CinemaHall cinemaHall)
        {
            return CinemaHallService.UpdateCinemaHall(id, cinemaHall);
        }
        [HttpDelete("{id}")]
        public CinemaHall DeleteCinemaHall(int id)
        {
            return CinemaHallService.DeleteCinemaHall(id);
        }

    }
}
