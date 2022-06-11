using BookMyShowTask.Models;
namespace BookMyShowTask.Services
{
    public interface ICityService
    {
        IEnumerable<City> GetCities();
        City GetCity(int id);
        City AddCity(City city);
        City UpdateCity(int id, City city);
        City DeleteCity(int id);


    }
}
