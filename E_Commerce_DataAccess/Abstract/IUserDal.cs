using E_Commerce_Core.DataAccess;
using E_Commerce_Core.Entities.Concrete;

namespace DataAccess.Abstract
{
   public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
