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
      public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
      {
         _mapper = mapper;
         _categoryDal = categoryDal;
      }

      /// <summary>
      public List<Category> AllGetList()
      {
         return _categoryDal.GetAllList();
      }
      public IResult Add(CategoryDto chief)
      {
         var category = _mapper.Map<Category>(chief);
         _categoryDal.Add(category);
         return new SuccessResult();
      }
      public IResult Update(CategoryDto categoryDto)
      {
         var category = _mapper.Map<Category>(categoryDto);
         _categoryDal.Update(category);
         return new SuccessResult();
      }
      public IResult Delete(CategoryDto chiefDto)
      {
         var chief = _mapper.Map<Category>(chiefDto);
         _categoryDal.Delete(chief);
         return new SuccessResult();
      }
      public IDataResult<IEnumerable<CategoryDto>> GetAll()
      {
         var Category = _categoryDal.GetAll();
         var CategoryDto = _mapper.Map<IEnumerable<CategoryDto>>(Category);
         return new SuccessDataResult<IEnumerable<CategoryDto>>(CategoryDto);
      }
      public IDataResult<CategoryDto> Get(int CategoryId)
      {
         var Category = _categoryDal.Get(aa => aa.CategoryId == CategoryId);
         var CategoryDto = _mapper.Map<CategoryDto>(Category);
         return new SuccessDataResult<CategoryDto>(CategoryDto);
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
         var Category = await _categoryDal.GetAsync(Category => Category.CategoryId == CategoryId);
         var CategoryDto = _mapper.Map<CategoryDto>(Category);
         return new SuccessDataResult<CategoryDto>(CategoryDto, Messages.CategoryFetched);
      }
      public async Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync()
      {
         var Category = await _categoryDal.GetAllAsync();
         var CategoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(Category);
         return new SuccessDataResult<IEnumerable<CategoryDto>>(CategoryDtos, Messages.CategoriesListed);
      }
      public async Task<IResult> UpdateAsync(CategoryDto categoryDto)
      {
         var category = _mapper.Map<Category>(categoryDto);
         await _categoryDal.UpdateAsync(category);
         return new SuccessResult(Messages.CategoryUpdated);
      }

   }
}
