using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class MovieService : IMovieService
    {
        readonly BookMyShowContext Context;
        public IMapper Mapper;
        public MovieService(BookMyShowContext context, IMapper mapper)
        {
            Mapper = mapper;
            Context = context;
        }
        public Movie GetMovie(int id)
        {
            var movie = Context.Movie.FirstOrDefault(x => x.ID == id);
            return Mapper.Map<Movie>(movie);
        }

        public IEnumerable<Movie> GetMovies()
        {
            var movie = Context.Movie.ToList();
            return Mapper.Map<IEnumerable<Movie>>(movie);
        }
        public Movie AddMovie(Movie movie)
        {
            if (movie != null)
            {
                Context.Movie.Add(movie);
                Context.SaveChanges();
                return Mapper.Map<Movie>(movie);
            }
            return null;
        }
        public Movie UpdateMovie(int id, Movie movie)
        {
            var movieData = Context.Movie.Where(model => model.ID == id).FirstOrDefault();
            if (movieData != null)
            {
                movie.ID = id;
                Context.Entry(movieData).CurrentValues.SetValues(movie);
                Context.SaveChanges();
            }
            return Mapper.Map<Movie>(movie);
        }
        public Movie DeleteMovie(int id)
        {
            var movie = Context.Movie.FirstOrDefault(x => x.ID == id);
            Context.Entry(movie).State = EntityState.Deleted;
            Context.SaveChanges();
            return Mapper.Map<Movie>(movie);
        }
    }
}
