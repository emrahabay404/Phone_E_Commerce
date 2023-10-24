using E_Commerce_Business.Abstract;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
   [Authorize]
   [Route("api/[controller]")]
   [ApiController]
   public class VersionController : ControllerBase
   {
      IVersionService _VersionService;
      public VersionController(IVersionService versionService)
      {
         _VersionService = versionService;
      }

      [HttpGet("versions")]
      public async Task<IActionResult> GetAll()
      {
         var result = await _VersionService.GetAllAsync();
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest(result);
      }

      [HttpPost]
      public async Task<IActionResult> Add(VersionDto versionDto)
      {
         var result = await _VersionService.AddAsync(versionDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpDelete("{versionId}")]
      public async Task<IActionResult> Delete(int versionId)
      {
         var result = await _VersionService.DeleteAsync(versionId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpPut]
      public async Task<IActionResult> Update(VersionDto versionDto)
      {
         var result = await _VersionService.UpdateAsync(versionDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpGet("{versionId}")]
      public async Task<IActionResult> Get(int versionId)
      {
         var result = await _VersionService.GetByIdAsync(versionId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }
   }
}
