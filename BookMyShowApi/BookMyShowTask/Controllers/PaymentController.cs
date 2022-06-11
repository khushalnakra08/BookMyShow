using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;



namespace BookMyShowTask.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService PaymentService;
        public PaymentController(IPaymentService payment)
        {

            PaymentService = payment;
        }
        [HttpGet("")]
        public IEnumerable<Payment> GetPayments()
        {
            return PaymentService.GetPayments();
        }
        [HttpGet("{id}")]
        public Payment GetPayment(int id)
        {
            return PaymentService.GetPayment(id);
        }
        [HttpPost("")]
        public Payment AddPayment(Payment payment)
        {
            return PaymentService.AddPayment(payment);
        }
        [HttpPut("{id}")]
        public Payment EditPayment(int id, Payment payment)
        {
            return PaymentService.UpdatePayment(id, payment);
        }
        [HttpDelete("{id}")]
        public Payment DeletePayment(int id)
        {
            return PaymentService.DeletePayment(id);
        }
    }
}
