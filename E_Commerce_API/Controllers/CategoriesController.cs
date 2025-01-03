﻿using Dapper;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IConfiguration _config;
        private readonly ICacheService _cacheService;

        public CategoriesController(ICacheService cacheService, IConfiguration configuration, ICategoryService categoryService, ILogger<CategoriesController> logger, IUserService userService)
        {
            _cacheService = cacheService;
            _config = configuration;
            _categoryService = categoryService;
            _logger = logger;
            _userService = userService;
        }

        // DAPPER
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllDapper()
        public async Task<IActionResult> GetAll()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
            IEnumerable<CategoryDto> _categories = await SelectAllCategories(connection);
            var expirationTime = DateTimeOffset.Now.AddMinutes(10);
            _cacheService.SetData("AllCategories", _categories, expirationTime);
            var cachedData = _cacheService.GetData<IEnumerable<CategoryDto>>("AllCategories");
            return Ok(new SuccessDataResult<IEnumerable<CategoryDto>>(cachedData, Messages.CategoriesListed));
        }

        [HttpPost]
        public async Task<ActionResult<List<CategoryDto>>> CreateCategoryDapper(CategoryDto categoryDto)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
            await connection.ExecuteAsync("insert  dbo.Categories(CategoryName) values( '" + categoryDto.CategoryName + "')");
            //return Ok(await SelectAllCategories(connection));
            return Ok(new SuccessResult(Messages.CategoryAdded));
        }

        [HttpDelete("{categoryId}")]
        public async Task<ActionResult<List<CategoryDto>>> DeleteCategory(int categoryId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
            await connection.ExecuteAsync("delete from dbo.Categories where categoryId = @categoryId", new { categoryId = categoryId });
            return Ok(new SuccessResult(Messages.Category_Deleted));
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int categoryId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
            var _Category = await connection.QueryFirstAsync<CategoryDto>("select * from dbo.Categories where CategoryId = @CategoryId",
                    new { CategoryId = categoryId });
            //return Ok(_Category);
            return Ok(new SuccessDataResult<CategoryDto>(_Category, Messages.Category_Fetched));
        }

        [HttpPut]
        public async Task<ActionResult<List<CategoryDto>>> UpdateCateory(CategoryDto categoryDto)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DapperConn"));
            await connection.ExecuteAsync("update dbo.Categories set CategoryName = @CategoryName where CategoryId = @CategoryId", categoryDto);
            return Ok(new SuccessResult(Messages.CategoryUpdated));
        }

        private static async Task<IEnumerable<CategoryDto>> SelectAllCategories(SqlConnection connection)
        {
            return await connection.QueryAsync<CategoryDto>("select * from dbo.Categories");
        }
        // DAPPER









        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _categoryService.GetAllAsync();
        //   var getUser = _userService.GetMyUsername();
        //   if (result.Success)
        //   {
        //      _logger.LogInformation("User : " + getUser + " - " + "Process Message : " + result.Message);
        //      return Ok(result);
        //   }
        //   else
        //   {
        //      _logger.LogInformation(result.Message);
        //      return BadRequest(result);
        //   }
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(CategoryDto categoryDto)
        //{
        //   var result = await _categoryService.AddAsync(categoryDto);
        //   if (result.Success)
        //   {
        //      _logger.LogInformation("Process Message : " + result.Message);
        //      return Ok(result);
        //   }
        //   else
        //   {
        //      _logger.LogInformation("Process Message : " + result.Message);
        //      return BadRequest();
        //   }
        //}

        //[HttpDelete("{CategoryId}")]
        //public async Task<IActionResult> Delete(int CategoryId)
        //{
        //   var result = await _categoryService.DeleteAsync(CategoryId);
        //   if (result.Success)
        //   {
        //      return Ok(result);
        //   }
        //   return BadRequest();
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update(CategoryDto categoryDto)
        //{
        //   var result = await _categoryService.UpdateAsync(categoryDto);
        //   if (result.Success)
        //   {
        //      return Ok(result);
        //   }
        //   return BadRequest();
        //}

        //[HttpGet("{categoryId}")]
        //public async Task<IActionResult> Get(int categoryId)
        //{
        //   var result = await _categoryService.GetByIdAsync(categoryId);
        //   if (result.Success)
        //   {
        //      return Ok(result);
        //   }
        //   return BadRequest();
        //}


    }
}