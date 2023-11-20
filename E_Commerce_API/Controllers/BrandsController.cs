using E_Commerce_Business.Abstract;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
   [Authorize]
   [Route("api/[controller]")]
   [ApiController]
   public class BrandsController : ControllerBase
   {
      IBrandService _brandService;
      public BrandsController(IBrandService brandService)
      {
         _brandService = brandService;
      }

      [HttpGet("brands")]
      public async Task<IActionResult> GetAll()
      {
         var result = await _brandService.GetAllAsync();
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest(result);
      }

      [HttpPost]
      public async Task<IActionResult> Add(BrandDto brandDto)
      {
         var result = await _brandService.AddAsync(brandDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpDelete("{brandId}")]
      public async Task<IActionResult> Delete(int brandId)
      {
         var result = await _brandService.DeleteAsync(brandId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpPut]
      public async Task<IActionResult> Update(BrandDto brandDto)
      {
         var result = await _brandService.UpdateAsync(brandDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpGet("{brandId}")]
      public async Task<IActionResult> Get(int brandId)
      {
         var result = await _brandService.GetByIdAsync(brandId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

   }
}
