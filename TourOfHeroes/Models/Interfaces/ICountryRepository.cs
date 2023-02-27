namespace TourOfHeroes.Models.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries { get; }
        Task<Country?> GetCountryById(int id);
    }
}
