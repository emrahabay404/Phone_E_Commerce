using E_Commerce_Core.Entities.Concrete;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.DTOs.User;

namespace E_Commerce_Business.Abstract
{
   public interface IUserService
   {
      List<OperationClaim> GetClaims(User user);
      void Add(User user);

      User GetByMail(string email);


      Task<IResult> UpdatePassword(UserChangePasswordDto dto);

      Task<IResult> UpdateUser(UserForRegisterDto userForRegisterDto, string password);

      Task<IDataResult<UserForRegisterDto>> GetMeInfo(int _userID);

      string GetMyUsername();
      int GetMyUserID();
   }
}
