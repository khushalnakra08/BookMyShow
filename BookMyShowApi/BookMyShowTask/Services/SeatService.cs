using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class SeatService : ISeatService
    {
        private readonly BookMyShowContext Context;
        public IMapper Mapper;
        public SeatService(BookMyShowContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public Seat AddSeat(Seat seat)
        {
            if (seat != null)
            {
                Context.Seat.Add(seat);
                Context.SaveChanges();
                return Mapper.Map<Seat>(seat);
            }
            return null;
        }

        public Seat DeleteSeat(int id)
        {
            var seat = Context.Seat.FirstOrDefault(x => x.Id == id);
            Context.Entry(seat).State = EntityState.Deleted;
            Context.SaveChanges();
            return Mapper.Map<Seat>(seat);
        }

        public Seat GetSeat(int id)
        {
            var seat = Context.Seat.FirstOrDefault(x => x.Id == id);
            return Mapper.Map<Seat>(seat);
        }

        public IEnumerable<Seat> GetSeats()
        {
            var seat = Context.Seat.ToList();
            return Mapper.Map<IEnumerable<Seat>>(seat);
        }

        public Seat UpdateSeat(int id, Seat seat)
        {
            var seatData = Context.Seat.Where(model => model.Id == id).FirstOrDefault();
            if (seatData != null)
            {
                seat.Id = id;
                Context.Entry(seatData).CurrentValues.SetValues(seat);
                Context.SaveChanges();
            }
            return Mapper.Map<Seat>(seat);
        }
    }
}
