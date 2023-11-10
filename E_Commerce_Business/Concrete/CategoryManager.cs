using AutoMapper;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Concrete
{
   public class CategoryManager : ICategoryService
   {
      IMapper _mapper;
      ICategoryDal _categoryDal;
      public ICacheService _CacheService { get; }
      public CategoryManager(ICategoryDal categoryDal, IMapper mapper, ICacheService cacheService)
      {
         _CacheService = cacheService;
         _mapper = mapper;
         _categoryDal = categoryDal;
      }
      //////////////ASYNC'S
      public async Task<IResult> AddAsync(CategoryDto category)
      {
         var Category = _mapper.Map<Category>(category);
         await _categoryDal.AddAsync(Category);
         return new SuccessResult(Messages.CategoryAdded);
      }

      public async Task<IResult> DeleteAsync(int CategoryId)
      {
         var _category = _mapper.Map<Category>(CategoryId);
         await _categoryDal.DeleteAsync(_category);
         return new SuccessResult(Messages.Category_Deleted);
      }

      public async Task<IDataResult<CategoryDto>> GetByIdAsync(int CategoryId)
      {
         var _Entity = await _categoryDal.GetAsync(Category => Category.CategoryId == CategoryId);
         var _EntityDto = _mapper.Map<CategoryDto>(_Entity);
         var expirationTime = DateTimeOffset.Now.AddMinutes(30);
         _CacheService.SetData("CategoriesByID", _EntityDto, expirationTime);
         var cachedData = _CacheService.GetData<CategoryDto>("CategoriesByID");
         return new SuccessDataResult<CategoryDto>(cachedData, Messages.Category_Fetched);
      }

      public async Task<IResult> UpdateAsync(CategoryDto categoryDto)
      {
         var category = _mapper.Map<Category>(categoryDto);
         await _categoryDal.UpdateAsync(category);
         return new SuccessResult(Messages.CategoryUpdated);
      }

      public async Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync()
      {
         var Category = await _categoryDal.GetAllAsync();
         var CategoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(Category);
         var expirationTime = DateTimeOffset.Now.AddMinutes(30);
         _CacheService.SetData("AllCategories", CategoryDtos, expirationTime);
         var cachedData = _CacheService.GetData<IEnumerable<CategoryDto>>("AllCategories");
         return new SuccessDataResult<IEnumerable<CategoryDto>>(cachedData, Messages.CategoriesListed);
      }

   }
}
