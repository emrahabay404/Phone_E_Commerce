using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using E_Commerce_Core.DataAccess.EntityFramework;
using E_Commerce_Entity.Concrete;

namespace E_Commerce_DataAccess.Concrete.EntityFramework
{
   public class EfOrderDal : EfEntityRepositoryBase<Order, E_Commerce_DbContext>, IOrderDal
   {

   }
}
