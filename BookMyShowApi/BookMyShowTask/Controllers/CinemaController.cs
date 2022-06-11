using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;


namespace BookMyShowTask.Controllers
{
    [Route("api/cinema")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService CinemaService;
        public CinemaController(ICinemaService cinema)
        {
            CinemaService = cinema;
        }
        [HttpGet("")]
        public IEnumerable<Cinema> GetCinemas()
        {
            return CinemaService.GetCinemas();
        }
        [HttpGet("{id}")]
        public Cinema GetCinema(int id)
        {
            return CinemaService.GetCinema(id);
        }
        [HttpGet("city/{id}")]
        public IEnumerable<Cinema> GetCinemaByCity(int id)
        {
            return CinemaService.GetCinemaByCity(id);
        }
        [HttpPost("")]
        public Cinema AddCinema(Cinema cinema)
        {
            return CinemaService.AddCinema(cinema);
        }
        [HttpPut("{id}")]
        public Cinema EditCinema(int id, Cinema cinema)
        {
            return CinemaService.UpdateCinema(id, cinema);
        }
        [HttpDelete("{id}")]
        public Cinema DeleteCinema(int id)
        {
            return CinemaService.DeleteCinema(id);
        }
    }
}
