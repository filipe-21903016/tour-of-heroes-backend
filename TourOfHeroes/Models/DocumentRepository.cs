using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Models.Interfaces;

namespace TourOfHeroes.Models
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly TourOfHeroesDbContext _db;

        public DocumentRepository(TourOfHeroesDbContext db)
        {
            _db = db;
        }

        public Task<Document?> GetDocumentById(int id)
        {
            return _db.Documents.FirstOrDefaultAsync(doc => doc.Id == id);
        }

        public async Task<int> UploadDocument(Document doc)
        {
            var document = doc;
                
            _db.Documents.Add(document);
            await _db.SaveChangesAsync();

            return document.Id;
        }
    }
}
