using DataAccess.Concrete.EntityFramework;
using E_Commerce_Core.DataAccess.EntityFramework;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_Entity.Concrete;
using E_Commerce_Entity.DTOs;

namespace E_Commerce_DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, E_Commerce_DbContext>, IProductDal
   {

      public List<ProductDetailDto> GetProductDetails()
      {
         using (E_Commerce_DbContext context = new E_Commerce_DbContext())
         {
            var result = from p in context.Products
                         join c in context.Categories
                         on p.CategoryId equals c.CategoryId
                         select new ProductDetailDto
                         {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            CategoryName = c.CategoryName,
                            UnitsInStock = p.UnitsInStock
                         };
            return result.ToList();
         }
      }
   }
}