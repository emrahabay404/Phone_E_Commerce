using AutoMapper;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_Business.Concrete
{
   public class ProductManager : IProductService
   {
      IMapper _mapper;
      IProductDal _productDal;
      public ICacheService _CacheService { get; }
      public ProductManager(IProductDal productDal, IMapper mapper, ICacheService cacheService)
      {
         _CacheService = cacheService;
         _mapper = mapper;
         _productDal = productDal;
      }

      public async Task<IResult> AddAsync(ProductDto productDto)
      {
         var _productDto = _mapper.Map<Product>(productDto);
         await _productDal.AddAsync(_productDto);
         return new SuccessResult(Messages.ProductAdded);
      }

      public List<Product> AllGetList()
      {
         return _productDal.GetAllList();
      }

      public async Task<IResult> DeleteAsync(int productId)
      {
         var _product = _mapper.Map<Product>(productId);
         await _productDal.DeleteAsync(_product);
         return new SuccessResult(Messages.Product_Deleted);
      }

      public async Task<IDataResult<IEnumerable<ProductDto>>> GetAllAsync()
      {
         var _Product = await _productDal.GetAllAsync();
         var _ProductDto = _mapper.Map<IEnumerable<ProductDto>>(_Product);
         var expirationTime = DateTimeOffset.Now.AddMinutes(2);
         _CacheService.SetData("AllProducts", _ProductDto, expirationTime);
         var cachedData = _CacheService.GetData<IEnumerable<ProductDto>>("AllProducts");
         return new SuccessDataResult<IEnumerable<ProductDto>>(cachedData, Messages.Products_Listed);
      }

      public async Task<IDataResult<ProductDto>> GetByIdAsync(int productId)
      {
         var _product = await _productDal.GetAsync(product => product.ProductId == productId);
         var _productDto = _mapper.Map<ProductDto>(_product);
         return new SuccessDataResult<ProductDto>(_productDto, Messages.Products_Listed);
      }

      public async Task<IResult> UpdateAsync(ProductDto productDto)
      {
         var _product = _mapper.Map<Product>(productDto);
         await _productDal.UpdateAsync(_product);
         return new SuccessResult(Messages.Product_Updated);
      }

   }
}
