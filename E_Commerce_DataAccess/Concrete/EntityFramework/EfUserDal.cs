using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using E_Commerce_Core.DataAccess.EntityFramework;
using E_Commerce_Core.Entities.Concrete;

namespace E_Commerce_DataAccess.Concrete.EntityFramework
{
   public class EfUserDal : EfEntityRepositoryBase<User, E_Commerce_DbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new E_Commerce_DbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
