using E_Commerce_Business.Abstract;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
   public class ModelController : ControllerBase
   {
      IModelService _ModelService;

      public ModelController(IModelService modelService)
      {
         _ModelService = modelService;
      }

      [HttpGet("models")]
      public async Task<IActionResult> GetAll()
      {
         var result = await _ModelService.GetAllAsync();
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest(result);
      }

      [HttpPost]
      public async Task<IActionResult> Add(ModelDto modelDto)
      {
         var result = await _ModelService.AddAsync(modelDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpDelete("{modelId}")]
      public async Task<IActionResult> Delete(int modelId)
      {
         var result = await _ModelService.DeleteAsync(modelId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpPut]
      public async Task<IActionResult> Update(ModelDto modelDto)
      {
         var result = await _ModelService.UpdateAsync(modelDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpGet("{modelId}")]
      public async Task<IActionResult> Get(int modelId)
      {
         var result = await _ModelService.GetByIdAsync(modelId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

   }
}
