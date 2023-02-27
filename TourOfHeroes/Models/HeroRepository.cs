using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Models.Interfaces;

namespace TourOfHeroes.Models
{

    public class HeroRepository : IHeroRepository
    {
        private readonly TourOfHeroesDbContext _dbContext;
        public HeroRepository(TourOfHeroesDbContext heroDb)
        {
            _dbContext = heroDb;
        }

        IEnumerable<Hero> IHeroRepository.AllHeroes
        {
            get => _dbContext.Heroes.Include(hero => hero.Country);
        }

        async Task<Hero> IHeroRepository.CreateHero(Hero hero)
        {   
            
            var country = await _dbContext.Countries.FirstOrDefaultAsync(c => c.Id == hero.CountryId);
            _dbContext.Heroes.Add(hero);
            await _dbContext.SaveChangesAsync();

            var addedHero = hero;
            addedHero.Country = country;
            return addedHero;
        }

        async Task IHeroRepository.DeleteHero(int id)
        {
            var hero = await _dbContext.Heroes.SingleOrDefaultAsync(h => h.Id == id);

            if(hero != null)
            {
                _dbContext.Remove(hero);
                await _dbContext.SaveChangesAsync();
            }
        }

        async Task<Hero?> IHeroRepository.GetHeroById(int id) => await _dbContext.Heroes.Include(hero=> hero.Country).FirstOrDefaultAsync(h => h.Id == id);

        IEnumerable<Hero> IHeroRepository.SearchHero(SearchTerms terms)
        {
            var heroes = _dbContext.Heroes.Include(hero => hero.Country);
            return  heroes
                .Where(hero => hero.Name.ToLower().Contains((terms.Name ?? "").ToLower()))
                .Where(hero => hero.PeopleSaved >= (terms.PeopleSaved ?? 0))
                .Where(hero => (terms.StartDate.HasValue) ? DateTime.Compare(hero.Date, (DateTime)terms.StartDate) >= 0 : true)
                .Where(hero => (terms.EndDate.HasValue) ? DateTime.Compare(hero.Date, (DateTime)terms.EndDate) <= 0 : true)
                .Where(hero => (terms.Countries != null && terms.Countries.Count() > 0) ? terms.Countries.Contains(hero.Country) : true);
        }

        async Task IHeroRepository.UpdateHero(Hero hero)
        {
            _dbContext.Heroes.Update(hero);
            await _dbContext.SaveChangesAsync();
        }
    }
}
