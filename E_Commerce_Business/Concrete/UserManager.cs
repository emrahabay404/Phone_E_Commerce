using AutoMapper;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Entities.Concrete;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_Core.Utilities.Security.Hashing;
using E_Commerce_Entity.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Commerce_Business.Concrete
{
   public class UserManager : IUserService
   {
      IUserDal _userDal;
      IHttpContextAccessor _contextAccessor;
      IMapper _mapper;
      E_Commerce_DbContext _Context;
      public UserManager(E_Commerce_DbContext context, IUserDal userDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
      {
         _Context = context;
         _contextAccessor = httpContextAccessor;
         _mapper = mapper;
         _userDal = userDal;
      }

      public List<OperationClaim> GetClaims(User user)
      {
         return _userDal.GetClaims(user);
      }

      public void Add(User user)
      {
         _userDal.Add(user);
      }

      public User GetByMail(string email)
      {
         return _userDal.Get(u => u.Email == email);
      }

      public string GetMyUsername()
      {
         var result = string.Empty;
         if (_contextAccessor is not null)
         {
            result = _contextAccessor.HttpContext.User?.Identity?.Name;
         }
         return result;
      }
      public int GetMyUserID()
      {
         var userID = "";
         if (_contextAccessor is not null)
         {
            userID = _contextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
         }
         else
         {
            userID = "0";
         }
         return int.Parse(userID);
      }

      public async Task<IResult> UpdateUser(UserForRegisterDto userForRegisterDto, string password)
      {
         byte[] passwordHash, passwordSalt;
         HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
         var user = new User
         {
            UserId = userForRegisterDto.UserId,
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            Username = userForRegisterDto.UserName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = userForRegisterDto.Status
         };
         await _userDal.UpdateAsync(user);
         return new SuccessResult(Messages.User_Updated);
      }

      public async Task<IDataResult<UserForRegisterDto>> GetMeInfo(int _userID)
      {
         var _user = await _userDal.GetAsync(x => x.UserId == _userID);
         var _userDto = _mapper.Map<UserForRegisterDto>(_user);
         return new SuccessDataResult<UserForRegisterDto>(_userDto, Messages.User_Fetched);
      }

      public async Task<IResult> UpdatePassword(UserChangePasswordDto dto)
      {
         byte[] passwordHash, passwordSalt;
         HashingHelper.CreatePasswordHash(dto.Password, out passwordHash, out passwordSalt);
         var _getUser = await _Context.Users.FirstOrDefaultAsync(x => x.UserId == dto.UserId);
         _getUser.PasswordHash = passwordHash;
         _getUser.PasswordSalt = passwordSalt;
         await _Context.SaveChangesAsync();
         return new SuccessResult(Messages.User_Password_Updated);
      }


   }
}