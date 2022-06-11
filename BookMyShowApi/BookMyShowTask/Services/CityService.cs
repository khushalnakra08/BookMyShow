using AutoMapper;
using BookMyShowTask.Models;
using Microsoft.EntityFrameworkCore;
namespace BookMyShowTask.Services
{
    public class CityService : ICityService
    {
        private readonly BookMyShowContext Context;
        public IMapper Mapper;
        public CityService(BookMyShowContext context, IMapper mapper)
        {
            Mapper = mapper;
            Context = context;
        }
        public City AddCity(City city)
        {
            if (city != null)
            {
                Context.City.Add(city);
                Context.SaveChanges();
                return Mapper.Map<City>(city);
            }
            return null;
        }

        public City DeleteCity(int id)
        {
            var city = Context.City.FirstOrDefault(x => x.Id == id);
            Context.Entry(city).State = EntityState.Deleted;
            Context.SaveChanges();
            return Mapper.Map<City>(city);
        }

        public IEnumerable<City> GetCities()
        {
            var city = Context.City.ToList();
            return Mapper.Map<IEnumerable<City>>(city);
        }

        public City GetCity(int id)
        {
            var city = Context.City.FirstOrDefault(x => x.Id == id);
            return Mapper.Map<City>(city);
        }

        public City UpdateCity(int id, City city)
        {
            var cityData = Context.City.Where(model => model.Id == id).FirstOrDefault();
            if (cityData != null)
            {
                city.Id = id;
                Context.Entry(cityData).CurrentValues.SetValues(city);
                Context.SaveChanges();
            }
            return Mapper.Map<City>(city);
        }
    }
}
