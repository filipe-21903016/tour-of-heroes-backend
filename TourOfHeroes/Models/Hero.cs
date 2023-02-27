using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourOfHeroes.Models
{
    public class Hero
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        public int PeopleSaved { get; set; } = 0;

        [Required]
        public int CountryId { get; set; }

        public Country? Country { get; set; }

        public int? DocumentId { get; set; }

    }
}
