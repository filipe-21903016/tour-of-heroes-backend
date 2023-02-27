namespace TourOfHeroes.Models.Interfaces
{
    public interface IDocumentRepository
    {
        Task<Document?> GetDocumentById(int id);
        Task<int> UploadDocument(Document doc);
    }
}
