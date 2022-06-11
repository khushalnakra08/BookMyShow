namespace BookMyShowTask.DTO
{
    public enum BookingStatus
    {
        Pending,
        Completed
    }
    public class BookingDTO
    {
        public int ID { get; set; }
        public int? NumberOfSeats { get; set; }
        public DateTime? Time { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public BookingStatus? Status { get; set; }
        public int? UserID { get; set; }
        public int? ShowId { get; set; }
    }
}
