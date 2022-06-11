using System.ComponentModel.DataAnnotations;

namespace BookMyShowTask.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }
        public string? Source { get; set; }
    }
}
