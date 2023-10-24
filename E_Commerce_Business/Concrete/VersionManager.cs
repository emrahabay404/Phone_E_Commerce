using AutoMapper;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_DataAccess.Concrete.EntityFramework;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;
using Version = E_Commerce_Entity.Concrete.Version;

namespace E_Commerce_Business.Concrete
{
   public class VersionManager : IVersionService
   {

      IMapper _mapper;
      IVersionDal _VersionDal;
      public VersionManager(IVersionDal versionDal, IMapper mapper)
      {
         _mapper = mapper;
         _VersionDal = versionDal;
      }
      public async Task<IResult> AddAsync(VersionDto versionDto)
      {
         var _Version = _mapper.Map<Version>(versionDto);
         await _VersionDal.AddAsync(_Version);
         return new SuccessResult(Messages.Version_Added);
      }
      public async Task<IResult> DeleteAsync(int versionID)
      {
         var _Version = _mapper.Map<Version>(versionID);
         await _VersionDal.DeleteAsync(_Version);
         return new SuccessResult(Messages.Version_Deleted);
      }

      public async Task<IDataResult<IEnumerable<VersionDto>>> GetAllAsync()
      {
         var _Version = await _VersionDal.GetAllAsync();
         var _VersionDto = _mapper.Map<IEnumerable<VersionDto>>(_Version);
         return new SuccessDataResult<IEnumerable<VersionDto>>(_VersionDto, Messages.Versions_Listed);
      }

      public async Task<IDataResult<VersionDto>> GetByIdAsync(int versionID)
      {
         var _Version = await _VersionDal.GetAsync(x => x.VersionID == versionID);
         var _VersionDto = _mapper.Map<VersionDto>(_Version);
         return new SuccessDataResult<VersionDto>(_VersionDto, Messages.Version_Fetched);
      }

      public async Task<IResult> UpdateAsync(VersionDto versionDto)
      {
         var _Version = _mapper.Map<Version>(versionDto);
         await _VersionDal.UpdateAsync(_Version);
         return new SuccessResult(Messages.Version_Updated);
      }
   }
}
