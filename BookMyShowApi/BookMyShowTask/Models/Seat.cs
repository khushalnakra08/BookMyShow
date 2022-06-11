using System.ComponentModel.DataAnnotations;
namespace BookMyShowTask.Models
{
    public enum SeatStatus
    {
        Empty,
        Occupied
    }
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        public int? Price { get; set; }
        public int? ShowId { get; set; }
        public int? BookingId { get; set; }
        public SeatStatus? Status { get; set; }
        public int? CinemaSeatId { get; set; }
    }
}
