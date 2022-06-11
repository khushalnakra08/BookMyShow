namespace BookMyShowTask.DTO
{
    public enum Method
    {
        UPI,
        DebitCard,
        CreditCard,
        NetBanking,
        Other
    }
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Time { get; set; }
        public int TransactionID { get; set; }
        public Method PaymentMethod { get; set; }
        public int BookingId { get; set; }
    }
}
