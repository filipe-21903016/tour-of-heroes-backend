using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TourOfHeroes.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [FromForm(Name="data")]
        public Byte[] Data { get; set; }

        [FromForm(Name = "heroId")]
        public int HeroId { get; set; }
    }
}
