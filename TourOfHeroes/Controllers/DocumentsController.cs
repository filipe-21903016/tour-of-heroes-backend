using Microsoft.AspNetCore.Mvc;
using TourOfHeroes.Models;
using TourOfHeroes.Models.Interfaces;

namespace TourOfHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentsController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById([FromRoute] int id)
        {
            var doc = await _documentRepository.GetDocumentById(id);
            if (doc == null)
            {
                return NotFound();
            }
            return new FileContentResult(doc.Data, "image/jpeg");
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument([FromForm] DocumentPostDto documentDto)
        {
            Document? doc = documentDto.ToDocument();
            if(doc == null)
            {
                return BadRequest();
            }

            return Ok(await _documentRepository.UploadDocument(doc));
        }
    }
}
