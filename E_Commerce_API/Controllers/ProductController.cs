using E_Commerce_Business.Abstract;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{

    [Route("api/[controller]")]
   [ApiController]
   public class ProductController : ControllerBase
   {
      IProductService _ProductService;
      private readonly IUserService _userService;
      private readonly ILogger<ProductController> _logger;
      public ProductController(IProductService ProductService, IUserService userService, ILogger<ProductController> logger)
      {
         _logger = logger;
         _ProductService = ProductService;
         _userService = userService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var result = await _ProductService.GetAllAsync();
         var getUser = _userService.GetMyUsername();
         if (result.Success)
         {
            _logger.LogInformation("User : " + getUser + " - " + "Process Message : " + result.Message);
            return Ok(result);
         }
         else
         {
            _logger.LogInformation(result.Message);
            return BadRequest(result);
         }
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
