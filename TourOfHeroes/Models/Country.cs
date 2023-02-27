using System.ComponentModel.DataAnnotations;

namespace TourOfHeroes.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public override bool Equals(Object? obj)
        {
            if (obj == null) return false;
            if (Object.ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;
            
            Country other = (Country)obj;
            return this.Id == other.Id;
        }
    }
}
