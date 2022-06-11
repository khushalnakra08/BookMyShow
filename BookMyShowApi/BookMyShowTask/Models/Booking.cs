using System.ComponentModel.DataAnnotations;

namespace BookMyShowTask.Models
{
    public enum BookingStatus
    {
        Pending,
        Completed
    }
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        public int? NumberOfSeats { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? Time { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public BookingStatus? Status { get; set; }
        public int? UserID { get; set; }
        public int? ShowId { get; set; }
    }
}
