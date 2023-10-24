using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Abstract
{
   public interface IBrandService
   {
      Task<IResult> AddAsync(BrandDto   brandDto);
      Task<IResult> UpdateAsync(BrandDto   brandDto);
      Task<IResult> DeleteAsync(int BrandID);
      Task<IDataResult<BrandDto>> GetByIdAsync(int BrandID);
      Task<IDataResult<IEnumerable<BrandDto>>> GetAllAsync();
   }
}
