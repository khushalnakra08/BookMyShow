using System.ComponentModel.DataAnnotations;
namespace BookMyShowTask.Models
{
    public enum Method
    {
        UPI,
        DebitCard,
        CreditCard,
        NetBanking,
        Other
    }
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int? Amount { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? Time { get; set; }
        public int? TransactionID { get; set; }
        public Method? PaymentMethod { get; set; }
        public int? BookingId { get; set; }
    }
}
