using DataAccess.Concrete.EntityFramework;
using E_Commerce_Core.DataAccess.EntityFramework;
using E_Commerce_DataAccess.Abstract;
using E_Commerce_Entity.Concrete;

namespace E_Commerce_DataAccess.Concrete.EntityFramework
{
   public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, E_Commerce_DbContext>, IOrderDetailDal
   {
   }
}
