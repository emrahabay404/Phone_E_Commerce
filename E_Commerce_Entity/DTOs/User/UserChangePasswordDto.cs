using E_Commerce_Core.Entities;

namespace E_Commerce_Entity.DTOs.User
{
   public class UserChangePasswordDto :IDto
   {
      public int UserId { get; set; }
      public string Password { get; set; }
   }
}
