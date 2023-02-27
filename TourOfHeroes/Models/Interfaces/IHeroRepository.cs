namespace TourOfHeroes.Models.Interfaces
{
    public interface IHeroRepository
    {
        IEnumerable<Hero> AllHeroes { get; }
        Task<Hero?> GetHeroById(int id);
        IEnumerable<Hero> SearchHero(SearchTerms terms);

        Task<Hero> CreateHero(Hero hero);
        Task UpdateHero(Hero hero);
        Task DeleteHero(int id);
    }
}
