using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Abstract
{
    public interface ICategoryService
   {
      //List<Category> AllGetList();
      //IResult Add(CategoryDto categoryDto);
      //IResult Update(CategoryDto categoryDto);
      //IResult Delete(CategoryDto chiefDto);
      //IDataResult<CategoryDto> Get(int CategoryNo);
      //IDataResult<IEnumerable<CategoryDto>> GetAll();

      //ASYNC'ss
      Task<IResult> AddAsync(CategoryDto category);
      Task<IResult> UpdateAsync(CategoryDto category);
      Task<IResult> DeleteAsync(int CategoryId);
      Task<IDataResult<CategoryDto>> GetByIdAsync(int CategoryId);
      Task<IDataResult<IEnumerable<CategoryDto>>> GetAllAsync();

   }
}

