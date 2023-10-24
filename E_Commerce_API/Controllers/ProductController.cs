using E_Commerce_Business.Abstract;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
   [Authorize]
   [Route("api/[controller]")]
   [ApiController]
   public class ProductController : ControllerBase
   {
      IProductService _ProductService;

      public ProductController(IProductService ProductService)
      {
         _ProductService = ProductService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var result = await _ProductService.GetAllAsync();
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest(result);
      }

      [HttpPost]
      public async Task<IActionResult> Add(ProductDto productDto)
      {
         var result = await _ProductService.AddAsync(productDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpDelete("{productId}")]
      public async Task<IActionResult> Delete(int productId)
      {
         var result = await _ProductService.DeleteAsync(productId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpPut]
      public async Task<IActionResult> Update(ProductDto productDto)
      {
         var result = await _ProductService.UpdateAsync(productDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpGet("{ProductId}")]
      public async Task<IActionResult> Get(int ProductId)
      {
         var result = await _ProductService.GetByIdAsync(ProductId);
         if (result.Success)
         {
            return Ok(result.Data);
         }
         return BadRequest();
      }

   }
}
