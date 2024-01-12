using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoes.Api.Services;

namespace Shoes.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   [Authorize(Roles = "Admin")]
   public class ShoesController : ControllerBase
   {
      private readonly IShoeRepository _shoeRepository;

      public ShoesController(IShoeRepository shoeRepository)
      {
         _shoeRepository = shoeRepository;
      }

      [HttpGet]
      public IActionResult Get()
      {
         return Ok(_shoeRepository.GetShoes());
      }

      [HttpDelete("{id:int}")]
      public IActionResult Delete(int id)
      {
         var shoeDeleted = _shoeRepository.DeleteShoe(id);

         return shoeDeleted ? NoContent() : NotFound();
      }
   }
}
