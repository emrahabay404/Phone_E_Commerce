using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Abstract
{
    public interface IProductService
   {
      //List<Product> AllGetList();
      //IResult Add(ProductDto ProductDto);
      //IResult Update(ProductDto ProductDto);
      //IResult Delete(ProductDto chiefDto);
      //IDataResult<ProductDto> Get(int ProductNo);
      //IDataResult<IEnumerable<ProductDto>> GetAll();

      //ASYNC'ss
      Task<IResult> AddAsync(ProductDto productDto);
      Task<IResult> UpdateAsync(ProductDto productDto);
      Task<IResult> DeleteAsync(int productId);
      Task<IDataResult<ProductDto>> GetByIdAsync(int productId);
      Task<IDataResult<IEnumerable<ProductDto>>> GetAllAsync();
      //Task DeleteAsync(int? productId);
   }

}
