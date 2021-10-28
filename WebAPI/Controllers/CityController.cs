using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Repo;
using WebAPI.Models;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository repo;
        public CityController(ICityRepository repo)
        {
            this.repo = repo;
        }

        // GET api/city
        [HttpGet("")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await repo.GetCitiesAsync();
            return Ok(cities);
        }

        // POST api/city/add?cityname=kirkuk
        [HttpPost("add")]
        [HttpPost("post")]
        [HttpPost("add/{cityname}")]
        //public async Task<IActionResult> AddCities(string cityName)
        public async Task<IActionResult> AddCities(City city)
        {
            //City city = new City();
            //city.Name = cityName;
            repo.AddCity(city);
            await repo.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            repo.DeleteCity(id);
            await repo.SaveAsync();
            return Ok(id);
        }

    }
}