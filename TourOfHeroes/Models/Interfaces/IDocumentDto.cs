using TourOfHeroes.Migrations;

namespace TourOfHeroes.Models.Interfaces
{
    public interface IDocumentDto
    {
        public Document? ToDocument();
    }
}
