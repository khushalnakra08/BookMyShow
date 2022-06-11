
using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly BookMyShowContext Context;
        public IMapper Mapper;
        public CinemaService(BookMyShowContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public Cinema AddCinema(Cinema cinema)
        {
            if (cinema != null)
            {
                Context.Cinema.Add(cinema);
                Context.SaveChanges();
                return Mapper.Map<Cinema>(cinema);
            }
            return null;
        }

        public Cinema DeleteCinema(int id)
        {
            var cinema = Context.Cinema.FirstOrDefault(x => x.Id == id);
            Context.Entry(cinema).State = EntityState.Deleted;
            Context.SaveChanges();
            return Mapper.Map<Cinema>(cinema);
        }

        public Cinema GetCinema(int id)
        {
            var cinema = Context.Cinema.FirstOrDefault(x => x.Id == id);
            return Mapper.Map<Cinema>(cinema);
        }

        public IEnumerable<Cinema> GetCinemaByCity(int id)
        {
            var cinema = Context.Cinema.Where(x => x.CityId == id).ToList();
            return Mapper.Map<IEnumerable<Cinema>>(cinema);
        }

        public IEnumerable<Cinema> GetCinemas()
        {
            var cinema = Context.Cinema.ToList();
            return Mapper.Map<IEnumerable<Cinema>>(cinema);
        }

        public Cinema UpdateCinema(int id, Cinema cinema)
        {
            var cinemaData = Context.Cinema.Where(model => model.Id == id).FirstOrDefault();
            if (cinemaData != null)
            {
                cinema.Id = id;
                Context.Entry(cinemaData).CurrentValues.SetValues(cinema);
                Context.SaveChanges();
            }
            return Mapper.Map<Cinema>(cinema);
        }
    }
}
