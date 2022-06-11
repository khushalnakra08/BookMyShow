using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetPayments();
        Payment GetPayment(int id);
        Payment AddPayment(Payment payment);
        Payment UpdatePayment(int id, Payment payment);
        Payment DeletePayment(int id);
    }
}
