using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;


namespace BookMyShowTask.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService MovieService;
        public MovieController(IMovieService movie)
        {
            MovieService = movie;
        }
        [HttpGet("")]
        public IEnumerable<Movie> GetMovies()
        {
            return MovieService.GetMovies();
        }
        [HttpGet("{id}")]
        public Movie GetMovie(int id)
        {
            return MovieService.GetMovie(id);
        }
        [HttpPost("")]
        public Movie AddMovie(Movie movie)
        {
            return MovieService.AddMovie(movie);
        }
        [HttpPut("{id}")]
        public Movie EditMovie(int id, Movie movie)
        {
            return MovieService.UpdateMovie(id, movie);
        }
        [HttpDelete("{id}")]
        public Movie DeleteMovie(int id)
        {
            return MovieService.DeleteMovie(id);
        }
    }
}
