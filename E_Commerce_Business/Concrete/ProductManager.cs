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
      public ProductManager(IProductDal productDal, IMapper mapper)
      {
         _mapper = mapper;
         _productDal = productDal;
      }

      public IResult Add(ProductDto productDto)
      {
         var _product = _mapper.Map<Product>(productDto);
         _productDal.Add(_product);
         return new SuccessResult();
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

      public IResult Delete(ProductDto  productDto)
      {
         var _product = _mapper.Map<Product>(productDto);
         _productDal.Delete(_product);
         return new SuccessResult();
      }

      public async Task<IResult> DeleteAsync(int productId)
      {
         var _product = _mapper.Map<Product>(productId);
         await _productDal.DeleteAsync(_product);
         return new SuccessResult(Messages.Product_Deleted);
      }

      public Task DeleteAsync(int? productId)
      {
         throw new NotImplementedException();
      }

      public IDataResult<ProductDto> Get(int ProductNo)
      {
         var _Product = _productDal.Get(aa => aa.ProductId == ProductNo);
         var _ProductDto = _mapper.Map<ProductDto>(_Product);
         return new SuccessDataResult<ProductDto>(_ProductDto);
      }

      public IDataResult<IEnumerable<ProductDto>> GetAll()
      {
         var _Product = _productDal.GetAll();
         var _ProductDto = _mapper.Map<IEnumerable<ProductDto>>(_Product);
         return new SuccessDataResult<IEnumerable<ProductDto>>(_ProductDto);
      }

      public async Task<IDataResult<IEnumerable<ProductDto>>> GetAllAsync()
      {
         var _ProductDto = await _productDal.GetAllAsync();
         var _Product = _mapper.Map<IEnumerable<ProductDto>>(_ProductDto);
         return new SuccessDataResult<IEnumerable<ProductDto>>(_Product, Messages.Products_Listed);
      }

      public async Task<IDataResult<ProductDto>> GetByIdAsync(int productId)
      {
         var _product = await _productDal.GetAsync(product => product.ProductId == productId);
         var _productDto = _mapper.Map<ProductDto>(_product);
         return new SuccessDataResult<ProductDto>(_productDto, Messages.Products_Listed);
      }

      public IResult Update(ProductDto ProductDto)
      {
         var _product = _mapper.Map<Product>(ProductDto);
         _productDal.Update(_product);
         return new SuccessResult();
      }

      public async Task<IResult> UpdateAsync(ProductDto productDto)
      {
         var _product = _mapper.Map<Product>(productDto);
         await _productDal.UpdateAsync(_product);
         return new SuccessResult(Messages.Product_Updated);
      }
   }
}
