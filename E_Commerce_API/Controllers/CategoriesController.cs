using E_Commerce_Business.Abstract;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
   [Authorize]
   [Route("api/[controller]")]
   [ApiController]
   public class CategoriesController : ControllerBase
   {
      private readonly ICategoryService _categoryService;
      private readonly IUserService _userService;
      private readonly ILogger<CategoriesController> _logger;
      // IConfiguration _config
      public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger, IUserService userService)
      {
         _categoryService = categoryService;
         _logger = logger;
         _userService = userService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var result = await _categoryService.GetAllAsync();
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
      public async Task<IActionResult> Add(CategoryDto categoryDto)
      {
         var result = await _categoryService.AddAsync(categoryDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpDelete("{CategoryId}")]
      public async Task<IActionResult> Delete(int CategoryId)
      {
         var result = await _categoryService.DeleteAsync(CategoryId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpPut]
      public async Task<IActionResult> Update(CategoryDto categoryDto)
      {
         var result = await _categoryService.UpdateAsync(categoryDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpGet("{categoryId}")]
      public async Task<IActionResult> Get(int categoryId)
      {
         var result = await _categoryService.GetByIdAsync(categoryId);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      //DAPPER eXAMPLE
      //[HttpGet]
      //public async Task<ActionResult<List<CategoryDto>>> GetAllDapper()
      //{
      //   using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
      //   IEnumerable<CategoryDto> _categories = await SelectAllCategories(connection);
      //   return Ok(_categories);
      //}
      //[HttpPost]
      //public async Task<ActionResult<List<CategoryDto>>> CreateCategoryDapper(CategoryDto categoryDto)
      //{
      //   using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
      //   await connection.ExecuteAsync("insert into dbo.Categories (CategoryName values (@CategoryName)", categoryDto);
      //   return Ok(await SelectAllCategories(connection));
      //}
      //[HttpDelete("{categoryId}")]
      //public async Task<ActionResult<List<CategoryDto>>> DeleteCategory(int categoryId)
      //{
      //   using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
      //   await connection.ExecuteAsync("delete from dbo.Categories where categoryId = @categoryId", new { Id = categoryId });
      //   return Ok(await SelectAllCategories(connection));
      //}
      //[HttpGet("{categoryId}")]
      //public async Task<ActionResult<CategoryDto>> GetCategory(int CategoryId)
      //{
      //   using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
      //   var _Category = await connection.QueryFirstAsync<CategoryDto>("select * from dbo.Categories where CategoryId = @CategoryId",
      //           new { Id = CategoryId });
      //   return Ok(_Category);
      //}
      //[HttpPut]
      //public async Task<ActionResult<List<CategoryDto>>> UpdateCateory(CategoryDto  categoryDto)
      //{
      //   using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
      //   await connection.ExecuteAsync("update dbo.Categories set CategoryName = @CategoryName where CategoryId = @CategoryId", categoryDto);
      //   return Ok(await SelectAllCategories(connection));
      //}
      //private static async Task<IEnumerable<CategoryDto>> SelectAllCategories(SqlConnection connection)
      //{
      //   return await connection.QueryAsync<CategoryDto>("select * from dbo.Categories");
      //}

   }
}