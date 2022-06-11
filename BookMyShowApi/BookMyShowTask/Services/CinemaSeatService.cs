using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class CinemaSeatService : ICinemaSeatService
    {
        private readonly BookMyShowContext Context;
        public IMapper Mapper;
        public CinemaSeatService(BookMyShowContext context, IMapper mapper)
        {
            Mapper = mapper;
            Context = context;
        }
        public CinemaSeat AddCinemaSeat(CinemaSeat cinemaSeat)
        {
            if (cinemaSeat != null)
            {
                Context.CinemaSeat.Add(cinemaSeat);
                Context.SaveChanges();
                return Mapper.Map<CinemaSeat>(cinemaSeat);
            }
            return null;
        }

        public CinemaSeat DeleteCinemaSeat(int id)
        {
            var cinemaSeat = Context.CinemaSeat.FirstOrDefault(x => x.Id == id);
            Context.Entry(cinemaSeat).State = EntityState.Deleted;
            Context.SaveChanges();
            return Mapper.Map<CinemaSeat>(cinemaSeat);
        }

        public CinemaSeat GetCinemaSeat(int id)
        {
            var cinemaSeat = Context.CinemaSeat.FirstOrDefault(x => x.Id == id);
            return Mapper.Map<CinemaSeat>(cinemaSeat);
        }

        public IEnumerable<CinemaSeat> GetCinemaSeatByCinemaHall(int id)
        {
            var cinemaSeat = Context.CinemaSeat.Where(x => x.CinemaHallId == id).ToList();
            return Mapper.Map<IEnumerable<CinemaSeat>>(cinemaSeat);
        }

        public IEnumerable<CinemaSeat> GetCinemaSeats()
        {
            var cinemaSeat = Context.CinemaSeat.ToList();
            return Mapper.Map<IEnumerable<CinemaSeat>>(cinemaSeat);
        }

        public CinemaSeat UpdateCinemaSeat(int id, CinemaSeat cinemaSeat)
        {
            var cinemaSeatData = Context.CinemaSeat.Where(model => model.Id == id).FirstOrDefault();
            if (cinemaSeatData != null)
            {
                cinemaSeat.Id = id;
                Context.Entry(cinemaSeatData).CurrentValues.SetValues(cinemaSeat);
                Context.SaveChanges();
            }
            return Mapper.Map<CinemaSeat>(cinemaSeat);
        }
    }
}
