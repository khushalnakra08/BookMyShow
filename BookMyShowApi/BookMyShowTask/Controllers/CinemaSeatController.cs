using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;


namespace BookMyShowTask.Controllers
{
    [Route("api/cinemaSeat")]
    [ApiController]
    public class CinemaSeatController : ControllerBase
    {
        private readonly ICinemaSeatService CinemaSeatService;
        public CinemaSeatController(ICinemaSeatService cinemaSeat)
        {
            CinemaSeatService = cinemaSeat;
        }
        [HttpGet("")]
        public IEnumerable<CinemaSeat> GetCinemaSeats()
        {
            return CinemaSeatService.GetCinemaSeats();
        }
        [HttpGet("{id}")]
        public CinemaSeat GetCinemaSeat(int id)
        {
            return CinemaSeatService.GetCinemaSeat(id); 
        }
        [HttpGet("cinemaHall/{id}")]
        public IEnumerable<CinemaSeat> GetCinemaSeatByCinemaHall(int id)
        {
            return CinemaSeatService.GetCinemaSeatByCinemaHall(id);
        }
        [HttpPost("")]
        public CinemaSeat AddCinemaSeat(CinemaSeat cinemaSeat)
        {
            return CinemaSeatService.AddCinemaSeat(cinemaSeat);
        }
        [HttpPut("{id}")]
        public CinemaSeat EditCinemaSeat(int id, CinemaSeat cinemaSeat)
        {
            return CinemaSeatService.UpdateCinemaSeat(id, cinemaSeat);
        }
        [HttpDelete("{id}")]
        public CinemaSeat DeleteCinemaSeat(int id)
        {
            return CinemaSeatService.DeleteCinemaSeat(id);
        }
    }
}
