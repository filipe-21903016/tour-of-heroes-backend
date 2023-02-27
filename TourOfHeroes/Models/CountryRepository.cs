using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Models.Interfaces;

namespace TourOfHeroes.Models
{
    public class CountryRepository : ICountryRepository
    {
        private readonly TourOfHeroesDbContext _dbContext;
        public CountryRepository(TourOfHeroesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        IEnumerable<Country> ICountryRepository.GetAllCountries => _dbContext.Countries;

        async Task<Country?> ICountryRepository.GetCountryById(int id) => await _dbContext.Countries.FirstOrDefaultAsync(c => c.Id == id); 
    }
}
