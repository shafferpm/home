using CityInfo.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.Current);

            //return new JsonResult(CitiesDataStore.Current);

            //return new JsonResult(
            //    new List<object>
            //    {
            //        new {id = 1, Name = "New York City"},
            //        new {id = 2, Name = "Antwerp"}
            //    });
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id) { 

            // Find the city.
            var cityToReturn = CitiesDataStore.Current.Cities
                .FirstOrDefault(c  => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();  // Returns a "Not Found, 404" error in Postman
            }

            return Ok(cityToReturn);

            //return new JsonResult(
            //    CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));            
        }
    }
}
