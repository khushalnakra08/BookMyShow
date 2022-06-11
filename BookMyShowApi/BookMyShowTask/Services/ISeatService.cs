using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface ISeatService
    {
        IEnumerable<Seat> GetSeats();
        Seat GetSeat(int id);
        Seat AddSeat(Seat seat);
        Seat UpdateSeat(int id, Seat seat);
        Seat DeleteSeat(int id);

    }
}
