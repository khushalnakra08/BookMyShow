using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly BookMyShowContext Context;
        public IMapper Mapper;
        public PaymentService(BookMyShowContext context, IMapper mapper)
        {
            Mapper = mapper;
            Context = context;
        }
        public Payment AddPayment(Payment payment)
        {
            if (payment != null)
            {
                Context.Payment.Add(payment);
                Context.SaveChanges();
                return Mapper.Map<Payment>(payment);
            }
            return null;
        }

        public Payment DeletePayment(int id)
        {
            var payment = Context.Payment.FirstOrDefault(x => x.Id == id);
            Context.Entry(payment).State = EntityState.Deleted;
            Context.SaveChanges();
            return Mapper.Map<Payment>(payment);
        }


        public Payment GetPayment(int id)
        {
            var payment = Context.Payment.FirstOrDefault(x => x.Id == id);
            return Mapper.Map<Payment>(payment);
        }

        public IEnumerable<Payment> GetPayments()
        {
            var payment = Context.Payment.ToList();
            return Mapper.Map<IEnumerable<Payment>>(payment);
        }

        public Payment UpdatePayment(int id, Payment payment)
        {
            var paymentData = Context.Payment.Where(model => model.Id == id).FirstOrDefault();
            if (paymentData != null)
            {
                payment.Id = id;
                Context.Entry(paymentData).CurrentValues.SetValues(payment);
                Context.SaveChanges();
            }
            return Mapper.Map<Payment>(payment);
        }
    }
}
