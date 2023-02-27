using TourOfHeroes.Models.Interfaces;

namespace TourOfHeroes.Models
{

    public class DocumentPostDto : IDocumentDto
    {
        public IFormFile File { get; set; }

        public Document? ToDocument()
        {
            if (File.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    return new Document
                    {
                        Data = fileBytes
                    };
                }
            }
            return null;
        }
    }
}
