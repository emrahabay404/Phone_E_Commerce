using E_Commerce_Core.Entities.Concrete;

namespace E_Commerce_Core.Utilities.Security.JWT
{
   public interface ITokenHelper
   {
      AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
   }
}
