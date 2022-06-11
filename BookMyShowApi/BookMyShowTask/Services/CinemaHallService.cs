using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class CinemaHallService : ICinemaHallService
    {
        private readonly BookMyShowContext Context;
        public IMapper Mapper;
        public CinemaHallService(BookMyShowContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public CinemaHall AddCinemaHall(CinemaHall cinemaHall)
        {
            if (cinemaHall != null)
            {
                Context.CinemaHall.Add(cinemaHall);
                Context.SaveChanges();
                return Mapper.Map<CinemaHall>(cinemaHall);
            }
            return null;
        }

        public CinemaHall DeleteCinemaHall(int id)
        {
            var cinemaHall = Context.CinemaHall.FirstOrDefault(c => c.Id == id);
            Context.Entry(cinemaHall).State = EntityState.Deleted;
            Context.SaveChanges();
            return Mapper.Map<CinemaHall>(cinemaHall);
        }

        public CinemaHall GetCinemaHall(int id)
        {
            var cinemaHall = Context.CinemaHall.FirstOrDefault(c => c.Id == id);
            return Mapper.Map<CinemaHall>(cinemaHall);
        }

        public IEnumerable<CinemaHall> GetCinemaHallByCinemaId(int id)
        {
            var cinemaHall = Context.CinemaHall.Where(x => x.CinemaId == id).ToList();
            return Mapper.Map<IEnumerable<CinemaHall>>(cinemaHall);
        }

        public IEnumerable<CinemaHall> GetCinemaHalls()
        {
            var cinemaHall = Context.CinemaHall.ToList();
            return Mapper.Map<IEnumerable<CinemaHall>>(cinemaHall);
        }

        public CinemaHall UpdateCinemaHall(int id, CinemaHall cinemaHall)
        {
            var cinemaData = Context.CinemaHall.Where(model => model.Id == id).FirstOrDefault();
            if (cinemaData != null)
            {
                cinemaHall.Id = id;
                Context.Entry(cinemaData).CurrentValues.SetValues(cinemaHall);
                Context.SaveChanges();
            }
            return Mapper.Map<CinemaHall>(cinemaHall);
        }
    }
}
