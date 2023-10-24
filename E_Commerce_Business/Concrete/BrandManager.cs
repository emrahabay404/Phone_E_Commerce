using AutoMapper;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Concrete
{
   public class BrandManager : IBrandService
   {
      IMapper _mapper;
      IBrandDal _BrandDal;
      public BrandManager(IBrandDal  brandDal, IMapper mapper)
      {
         _mapper = mapper;
         _BrandDal = brandDal;
      }

      public async Task<IResult> AddAsync(BrandDto  brandDto)
      {
         var _brand = _mapper.Map<Brand>(brandDto);
         await _BrandDal.AddAsync(_brand);
         return new SuccessResult(Messages.Brand_Added);
      }

      public async Task<IResult> DeleteAsync(int BrandID)
      {
         var _brand = _mapper.Map<Brand>(BrandID);
         await _BrandDal.DeleteAsync(_brand);
         return new SuccessResult(Messages.Brand_Deleted);
      }

      public async Task<IDataResult<IEnumerable<BrandDto>>> GetAllAsync()
      {
         var _Brand = await _BrandDal.GetAllAsync();
         var _BrandDto = _mapper.Map<IEnumerable<BrandDto>>(_Brand);
         return new SuccessDataResult<IEnumerable<BrandDto>>(_BrandDto, Messages.Brands_Listed);
      }

      public async Task<IDataResult<BrandDto>> GetByIdAsync(int BrandID)
      {
         var _Brand = await _BrandDal.GetAsync(x => x.BrandID == BrandID);
         var _BrandDto = _mapper.Map<BrandDto>(_Brand);
         return new SuccessDataResult<BrandDto>(_BrandDto, Messages.Brand_Fetched);
      }

      public async Task<IResult> UpdateAsync(BrandDto   brandDto)
      {
         var _Brand = _mapper.Map<Brand>(brandDto);
         await _BrandDal.UpdateAsync(_Brand);
         return new SuccessResult(Messages.Brand_Updated);
      }
   }
}
