using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface ICinemaService
    {
        IEnumerable<Cinema> GetCinemas();
        Cinema GetCinema(int id);
        Cinema AddCinema(Cinema cinema);
        Cinema UpdateCinema(int id, Cinema cinema);
        Cinema DeleteCinema(int id);
        IEnumerable<Cinema> GetCinemaByCity(int id);
    }
}
