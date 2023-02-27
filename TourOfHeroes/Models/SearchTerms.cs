using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;

namespace TourOfHeroes.Models
{
    public class SearchTerms
    {
        public string? Name {get; set; }
        public int? PeopleSaved { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<Country>? Countries { get; set; }

        public bool isClean()
        {
            return Countries == null && Name == string.Empty && PeopleSaved == null && StartDate == null && EndDate == null;
        }
    }
}
