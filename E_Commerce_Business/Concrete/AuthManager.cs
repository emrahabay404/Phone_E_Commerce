using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Entities.Concrete;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_Core.Utilities.Security.Hashing;
using E_Commerce_Core.Utilities.Security.JWT;
using E_Commerce_Entity.DTOs.User;

namespace E_Commerce_Business.Concrete
{
   public class AuthManager : IAuthService
   {
      private readonly IUserService _userService;
      private readonly ITokenHelper _tokenHelper;

      public AuthManager(IUserService userService, ITokenHelper tokenHelper)
      {
         _userService = userService;
         _tokenHelper = tokenHelper;
      }

      public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
      {
         byte[] passwordHash, passwordSalt;
         HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
         var user = new User
         {
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            Username = userForRegisterDto.UserName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
         };
         _userService.Add(user);
         return new SuccessDataResult<User>(user, Messages.User_Register_Successful);
      }

      public IDataResult<User> Login(UserForLoginDto userForLoginDto)
      {
         var userToCheck = _userService.GetByMail(userForLoginDto.Email);
         if (userToCheck == null)
         {
            return new ErrorDataResult<User>(Messages.UserNotFound);
         }

         if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
         {
            return new ErrorDataResult<User>(Messages.PasswordError);
         }

         return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
      }

      public IResult UserExists(string email)
      {
         if (_userService.GetByMail(email) != null)
         {
            return new ErrorResult(Messages.UserAlreadyExists);
         }
         return new SuccessResult();
      }

      public IDataResult<AccessToken> CreateAccessToken(User user)
      {
         var claims = _userService.GetClaims(user);
         var accessToken = _tokenHelper.CreateToken(user, claims);
         return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
      }

   }
}
