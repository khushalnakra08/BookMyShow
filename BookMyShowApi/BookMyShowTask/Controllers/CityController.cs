using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;


namespace BookMyShowTask.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService CityService;
        public CityController(ICityService city)
        {

            CityService = city;
        }
        [HttpGet("")]
        public IEnumerable<City> GetCities()
        {
            return CityService.GetCities();
        }
        [HttpGet("{id}")]
        public City GetCity(int id)
        {
            return CityService.GetCity(id);
        }
        [HttpPost("")]
        public City AddCity(City city)
        {
            return CityService.AddCity(city);
        }
        [HttpPut("{id}")]
        public City EditCity(int id, City city)
        {
            return CityService.UpdateCity(id, city);
        }
        [HttpDelete("{id}")]
        public City DeleteCity(int id)
        {
            return CityService.DeleteCity(id);
        }
    }
}
