using ElasticSearch_Basic_Api.Models;
using ElasticSearch_Basic_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch_Basic_Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ESController : ControllerBase
   {
      private readonly Services.IElasticSearchService<Product> _elasticSearchService;

      public ESController(IElasticSearchService<Product> elasticSearchService)
      {
         _elasticSearchService = elasticSearchService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllDocuments()
      {
         var response = await _elasticSearchService.GetAllDocuments();
         return Ok(response);
      }

      [HttpPost]
      public async Task<IActionResult> CreateDocument([FromBody] Product document)
      {
         var result = await _elasticSearchService.CreateDocumentAsync(document);
         return Ok(result);
      }

      [HttpGet]
      [Route("read/{id}")]
      public async Task<IActionResult> GetDocument(int id)
      {
         var document = await _elasticSearchService.GetDocumentAsync(id);
         if (document == null)
         {
            return NotFound();
         }
         return Ok(document);
      }

      [HttpPut]
      public async Task<IActionResult> UpdateDocument([FromBody] Product _product)
      {
         var result = await _elasticSearchService.UpdateDocumentasync(_product);
         return Ok(result);
      }

      [HttpDelete]
      [Route("delete/{id}")]
      public async Task<IActionResult> DeleteDocument(int id)
      {
         var result = await _elasticSearchService.DeleteDocumentAsync(id);
         return Ok(result);
      }

   }
}
