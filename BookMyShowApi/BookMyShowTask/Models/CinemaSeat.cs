using System.ComponentModel.DataAnnotations;
namespace BookMyShowTask.Models
{
    public class CinemaSeat
    {
        [Key]
        public int Id { get; set; }
        public int? SeatNumber { get; set; }
        public int? CinemaHallId { get; set; }
    }
}
