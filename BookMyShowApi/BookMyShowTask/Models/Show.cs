using System.ComponentModel.DataAnnotations;
namespace BookMyShowTask.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        public int? CinemaHallId { get; set; }
        public int? MovieId { get; set; }
    }
}
