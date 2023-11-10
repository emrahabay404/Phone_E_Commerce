using AutoMapper;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_DataAccess.Concrete.EntityFramework;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Concrete
{
   public class ModelManager : IModelService
   {
      IMapper _mapper;
      IModelDal _ModelDal;
      public ICacheService _CacheService { get; }
      public ModelManager(IModelDal modelDal, IMapper mapper, ICacheService cacheService)
      {
         _CacheService = cacheService;
         _mapper = mapper;
         _ModelDal = modelDal;
      }

      public async Task<IResult> AddAsync(ModelDto modelDto)
      {
         var _model = _mapper.Map<Model>(modelDto);
         await _ModelDal.AddAsync(_model);
         return new SuccessResult(Messages.Model_Added);
      }

      public async Task<IResult> DeleteAsync(int ModelID)
      {
         var _model = _mapper.Map<Model>(ModelID);
         await _ModelDal.DeleteAsync(_model);
         return new SuccessResult(Messages.Model_Deleted);
      }

      public async Task<IDataResult<IEnumerable<ModelDto>>> GetAllAsync()
      {
         var _entity = await _ModelDal.GetAllAsync();
         var entityDtos = _mapper.Map<IEnumerable<ModelDto>>(_entity);
         var expirationTime = DateTimeOffset.Now.AddMinutes(30);
         _CacheService.SetData("AllModels", entityDtos, expirationTime);
         var cachedData = _CacheService.GetData<IEnumerable<ModelDto>>("AllModels");
         return new SuccessDataResult<IEnumerable<ModelDto>>(cachedData, Messages.Models_Listed);
      }

      public async Task<IDataResult<ModelDto>> GetByIdAsync(int ModelID)
      {
         var _Entity = await _ModelDal.GetAsync(Model => Model.ModelID == ModelID);
         var _EntityDto = _mapper.Map<ModelDto>(_Entity);
         var expirationTime = DateTimeOffset.Now.AddMinutes(30);
         _CacheService.SetData("ModelByID", _EntityDto, expirationTime);
         var cachedData = _CacheService.GetData<ModelDto>("ModelByID");
         return new SuccessDataResult<ModelDto>(cachedData, Messages.Model_Fetched);

         //var _model = await _ModelDal.GetAsync(x => x.ModelID == ModelID);
         //var _modelDto = _mapper.Map<ModelDto>(_model);
         //return new SuccessDataResult<ModelDto>(_modelDto, Messages.Model_Fetched);
      }

      public async Task<IResult> UpdateAsync(ModelDto modelDto)
      {
         var _model = _mapper.Map<Model>(modelDto);
         await _ModelDal.UpdateAsync(_model);
         return new SuccessResult(Messages.Model_Updated);
      }

   }
}
