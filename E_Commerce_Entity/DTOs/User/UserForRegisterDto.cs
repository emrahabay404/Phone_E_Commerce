using E_Commerce_Core.Entities;

namespace E_Commerce_Entity.DTOs.User
{
   public class UserForRegisterDto : IDto
   {
      public int UserId { get; set; }
      public string Email { get; set; }
      public string UserName { get; set; }
      public string Password { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public bool Status { get; set; }
   }
}
