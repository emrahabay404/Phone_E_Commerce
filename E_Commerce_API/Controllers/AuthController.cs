using DataAccess.Concrete.EntityFramework;
using E_Commerce_Business.Abstract;
using E_Commerce_Business.Constants;
using E_Commerce_Core.Utilities.Results;
using E_Commerce_Entity.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;

namespace E_Commerce_API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthController : Controller
   {
      IAuthService _authService;
      IUserService _userService;
      E_Commerce_DbContext _Context;
      public AuthController(E_Commerce_DbContext context, IAuthService authService, IUserService userService)
      {
         _Context = context;
         _authService = authService;
         _userService = userService;
      }

      [HttpPost("login")]
      public async Task<ActionResult> Login(UserForLoginDto userForLoginDto)
      {
         var userToLogin = _authService.Login(userForLoginDto);
         if (!userToLogin.Success)
         {
            return BadRequest(userToLogin.Message);
         }
         var result = _authService.CreateAccessToken(userToLogin.Data);
         if (result.Success)
         {
            UpdateUserToken(result.Data.Token, result.Data.Expiration, userForLoginDto.Email);
            //Response.Cookies.Append("token", result.Data.Token);
            return Ok(result);
         }
         return BadRequest(result.Message);
      }

      [HttpPost("register")]
      public ActionResult Register(UserForRegisterDto userForRegisterDto)
      {
         var userExists = _authService.UserExists(userForRegisterDto.Email);
         if (!userExists.Success)
         {
            return BadRequest(userExists.Message);
         }
         var passMessage = CheckPasswordStrength(userForRegisterDto.Password);
         if (!string.IsNullOrEmpty(passMessage))
         {
            return BadRequest(new { Message = passMessage.ToString() });
         }
         var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
         var result = _authService.CreateAccessToken(registerResult.Data);
         if (result.Success)
         {
            //return Ok(result);
            return Ok(new SuccessResult(Messages.User_Register_Successful));
         }
         return BadRequest(result.Message);
      }

      [HttpPut("user"), Authorize]
      public async Task<ActionResult> UpdateUser(UserForRegisterDto _user)
      {
         _user.UserId = _userService.GetMyUserID();
         var result = await _userService.UpdateUser(_user, _user.Password);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      //[HttpGet("GETUSERID"), Authorize]
      //public int GetMyUserID()
      //{
      //   return _userService.GetMyUserID();
      //}
      //[HttpGet("GETUSERNAME"), Authorize]
      //public string GetMe()
      //{
      //   return _userService.GetMyUsername();
      //}

      [HttpPut("changepassword"), Authorize]
      public async Task<ActionResult> UpdatePassword(UserChangePasswordDto passwordDto)
      {
         passwordDto.UserId = _userService.GetMyUserID();
         //var result = await _userService.UpdatePassword(passwordDto);
         //if (result.Success)
         //{
         //   return Ok(result);
         //}
         //return BadRequest();
         var result = await _userService.UpdatePassword(passwordDto);
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      [HttpGet("user"), Authorize]
      public async Task<IActionResult> GetUser()
      {
         var result = await _userService.GetMeInfo(_userService.GetMyUserID());
         if (result.Success)
         {
            return Ok(result);
         }
         return BadRequest();
      }

      private void UpdateUserToken(string token, DateTime expiration, string _Email)
      {
         var user = _Context.Users.FirstOrDefault(x => x.Email == _Email);
         user.Token = token;
         user.RefreshTokenExpiryTime = expiration;
         _Context.SaveChanges();
      }

      [HttpGet("logout"), Authorize]
      public async Task<IActionResult> LogOut()
      {
         var user = await _Context.Users.FirstOrDefaultAsync(x => x.UserId == _userService.GetMyUserID());
         user.Token = null;
         user.RefreshToken = null;
         user.RefreshTokenExpiryTime = DateTime.Now;
         await _Context.SaveChangesAsync();
         return Unauthorized(Messages.AccessTokenInvalid);
         //Response.Cookies.Delete("token");
      }

      private static string CheckPasswordStrength(string _password)
      {
         StringBuilder sb = new StringBuilder();
         if (_password.Length < 9)
            sb.Append("Minimum password length should be 8" + Environment.NewLine);
         if (!(Regex.IsMatch(_password, "[a-z]") && Regex.IsMatch(_password, "[A-Z]") && Regex.IsMatch(_password, "[0-9]")))
            sb.Append("Password should be AlphaNumeric" + Environment.NewLine);
         if (!Regex.IsMatch(_password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
            sb.Append("Password should contain special charcter" + Environment.NewLine);
         return sb.ToString();
      }

   }
}

