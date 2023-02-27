using TourOfHeroes.Models.Interfaces;

namespace TourOfHeroes.Models
{
    public class HeroGetDto : IHeroDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int? PeopleSaved { get; set; }
        public int CountryId { get; set; }
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
                DocumentId = DocumentId
            };
        }
    }
}
