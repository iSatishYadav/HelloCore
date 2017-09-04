using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Api.Controllers
{
    //[Route("api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet("api/cities")]
        //public JsonResult GetCities()
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("api/cities/{id}")]
        //public JsonResult GetCity(int id)
        public IActionResult GetCity(int id)

        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id);
            if (city == null)
                return NotFound();
            else
                return Ok(city);
        }
    }
}
