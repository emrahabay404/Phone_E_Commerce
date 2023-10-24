using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Abstract
{
   public interface IModelService
   {
      Task<IResult> AddAsync(ModelDto  modelDto);
      Task<IResult> UpdateAsync(ModelDto modelDto);
      Task<IResult> DeleteAsync(int ModelID);
      Task<IDataResult<ModelDto>> GetByIdAsync(int ModelID);
      Task<IDataResult<IEnumerable<ModelDto>>> GetAllAsync();
   }
}
