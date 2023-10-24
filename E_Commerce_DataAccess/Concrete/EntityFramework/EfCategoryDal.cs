using DataAccess.Concrete.EntityFramework;
using E_Commerce_Core.DataAccess.EntityFramework;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_Entity.Concrete;

namespace E_Commerce_DataAccess.Concrete.EntityFramework
{
   public class EfCategoryDal : EfEntityRepositoryBase<Category, E_Commerce_DbContext>, ICategoryDal
    {

    }
}
