using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TourOfHeroes.Models.Interfaces;

namespace TourOfHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult GetCountries() => Ok(_countryRepository.GetAllCountries);

        [HttpGet("{id}")]
        public IActionResult GetCountryById([FromRoute] int id) => Ok(_countryRepository.GetCountryById(id));
    }
}
