using AutoMapper;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_Entity.DTOs;
using Version = E_Commerce_Entity.Concrete.Version;

namespace E_Commerce_Business.Concrete
{
   public class VersionManager : IVersionService
   {
      public ICacheService _CacheService { get; }
      IMapper _mapper;
      IVersionDal _VersionDal;
      public VersionManager(IVersionDal versionDal, IMapper mapper, ICacheService cacheService)
      {
         _CacheService = cacheService;
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
         var _entity = await _VersionDal.GetAllAsync();
         var entityDtos = _mapper.Map<IEnumerable<VersionDto>>(_entity);
         var expirationTime = DateTimeOffset.Now.AddMinutes(30);
         _CacheService.SetData("AllVersions", entityDtos, expirationTime);
         var cachedData = _CacheService.GetData<IEnumerable<VersionDto>>("AllVersions");
         return new SuccessDataResult<IEnumerable<VersionDto>>(cachedData, Messages.Versions_Listed);
      }

      public async Task<IDataResult<VersionDto>> GetByIdAsync(int versionID)
      {
         var _Entity = await _VersionDal.GetAsync(Category => Category.VersionID == versionID);
         var _EntityDto = _mapper.Map<VersionDto>(_Entity);
         var expirationTime = DateTimeOffset.Now.AddMinutes(30);
         _CacheService.SetData("VersionByID", _EntityDto, expirationTime);
         var cachedData = _CacheService.GetData<VersionDto>("VersionByID");
         return new SuccessDataResult<VersionDto>(cachedData, Messages.Version_Fetched);
      }

      public async Task<IResult> UpdateAsync(VersionDto versionDto)
      {
         var _Version = _mapper.Map<Version>(versionDto);
         await _VersionDal.UpdateAsync(_Version);
         return new SuccessResult(Messages.Version_Updated);
      }

   }
}
