using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface ICinemaHallService
    {
        IEnumerable<CinemaHall> GetCinemaHalls();
        CinemaHall GetCinemaHall(int id);
        CinemaHall AddCinemaHall(CinemaHall cinemaHall);
        CinemaHall UpdateCinemaHall(int id, CinemaHall cinemaHall);
        CinemaHall DeleteCinemaHall(int id); 
        IEnumerable<CinemaHall> GetCinemaHallByCinemaId(int id);
    }
}
