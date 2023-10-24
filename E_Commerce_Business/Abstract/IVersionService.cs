using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Abstract
{
   public interface IVersionService
   {
      Task<IResult> AddAsync(VersionDto versionDto);
      Task<IResult> UpdateAsync(VersionDto  versionDto);
      Task<IResult> DeleteAsync(int versionID);
      Task<IDataResult<VersionDto>> GetByIdAsync(int versionID);
      Task<IDataResult<IEnumerable<VersionDto>>> GetAllAsync();
   }
}
