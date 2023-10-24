using E_Commerce_Core.DataAccess;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
   {
      List<ProductDetailDto> GetProductDetails();
   }
}
