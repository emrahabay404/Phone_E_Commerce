using DataAccess.Concrete.EntityFramework;
using E_Commerce_Core.DataAccess.EntityFramework;
using E_Commerce_DataAccess.Abstract;

namespace E_Commerce_DataAccess.Concrete.EntityFramework
{
   public class EfVersionDal : EfEntityRepositoryBase<E_Commerce_Entity.Concrete.Version, E_Commerce_DbContext>, IVersionDal
   {
   }
}
