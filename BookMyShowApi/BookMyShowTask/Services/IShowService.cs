using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface IShowService
    {
        IEnumerable<Show> GetShows();
        Show GetShow(int id);
        Show AddShow(Show show);
        Show UpdateShow(int id, Show show);
        Show DeleteShow(int id);
        IEnumerable<Show> GetShowByCinemaHallId(int id);

    }
}
