using TourOfHeroes.Models.Interfaces;

namespace TourOfHeroes.Models
{
    public class HeroPutDto: IHeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int? PeopleSaved { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int? DocumentId { get; set; }

        public Hero ToHero()
        {
            return new Hero()
            {
                Id = Id,
                Name = Name,
                Date = Date,
                PeopleSaved = PeopleSaved ?? 0,
                CountryId = CountryId,
                Country = Country,
                DocumentId = DocumentId
            };
        }
    }
}
