using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;

namespace BookMyShowTask.Controllers
{
    [Route("api/show")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService ShowService;
        public ShowController(IShowService show)
        {

            ShowService = show;
        }
        [HttpGet("")]
        public IEnumerable<Show> GetShows()
        {  
            return ShowService.GetShows();
        }
        [HttpGet("{id}")]
        public Show GetShow(int id)
        {
            return ShowService.GetShow(id);
        }
        [HttpGet("cinemaHall/{id}")]
        public IEnumerable<Show> GetShowByCinemaHall(int id)
        {
            return ShowService.GetShowByCinemaHallId(id);
        }
        [HttpPost("")]
        public Show AddShow(Show show)
        {
            return ShowService.AddShow(show);
        }
        [HttpPut("{id}")]
        public Show EditShow(int id, Show show)
        {
            return ShowService.UpdateShow(id, show);
        }
        [HttpDelete("{id}")]
        public Show DeleteShow(int id)
        {
            return ShowService.DeleteShow(id);
        }
    }
}
