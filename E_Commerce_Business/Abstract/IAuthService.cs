using E_Commerce_Core.Entities.Concrete;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_Core.Utilities.Security.JWT;
using E_Commerce_Entity.DTOs.User;

namespace E_Commerce_Business.Abstract
{
   public interface IAuthService
   {
      IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
      IDataResult<User> Login(UserForLoginDto userForLoginDto);
      IResult UserExists(string email);
      IDataResult<AccessToken> CreateAccessToken(User user);

   }
}
