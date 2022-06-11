using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShowTask.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? Source { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? Duration { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? ReleasedDate { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? ModifiedOn { get; set; }

        public bool? IsDeleted { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? DateDeleted { get; set; }

    }
}