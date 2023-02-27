using Microsoft.AspNetCore.Mvc;
using TourOfHeroes.Models;
using TourOfHeroes.Models.Interfaces;

namespace TourOfHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase {
        private readonly IHeroRepository _heroRepository;
        public HeroesController(IHeroRepository heroRepository)
        {
            this._heroRepository = heroRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroById([FromRoute] int id) =>  Ok(await _heroRepository.GetHeroById(id));


        [HttpGet()]
        public IActionResult GetHeroes() => Ok(_heroRepository.AllHeroes);

        [HttpPost("search")]
        public IActionResult SearchHeroes([FromBody] SearchTerms terms)
        {
            return Ok(_heroRepository.SearchHero(terms));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHero([FromBody] HeroPutDto heroDto)
        {
            _heroRepository.UpdateHero(heroDto.ToHero());
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero([FromBody] HeroPostDto heroDto) => Ok(await _heroRepository.CreateHero(heroDto.ToHero()));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            await _heroRepository.DeleteHero(id);
            return Ok();
        }
    }
}
