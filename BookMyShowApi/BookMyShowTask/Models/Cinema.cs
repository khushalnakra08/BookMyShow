
using System.ComponentModel.DataAnnotations;
namespace BookMyShowTask.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TotalCinemaHall { get; set; }
        public int? CityId { get; set; }

    }
}
