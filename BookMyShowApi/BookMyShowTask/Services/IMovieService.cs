using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovie(int id);
        Movie AddMovie(Movie movie);
        Movie UpdateMovie(int id, Movie movie);
        Movie DeleteMovie(int id);
    }
}
