using System.ComponentModel.DataAnnotations;
namespace BookMyShowTask.Models
{
    public class CinemaHall
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TotalSeats { get; set; }
        public int? CinemaId { get; set; }
    }
}
