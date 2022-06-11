using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface ICinemaSeatService
    {
        IEnumerable<CinemaSeat> GetCinemaSeats();
        CinemaSeat GetCinemaSeat(int id);
        CinemaSeat AddCinemaSeat(CinemaSeat cinemaSeat);
        CinemaSeat UpdateCinemaSeat(int id, CinemaSeat cinemaSeat); 
        CinemaSeat DeleteCinemaSeat(int id);
        IEnumerable<CinemaSeat> GetCinemaSeatByCinemaHall(int id);

    }
}
