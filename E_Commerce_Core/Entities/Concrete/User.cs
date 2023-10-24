
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Core.Entities.Concrete
{
   public class User : IEntity
   {
      [Key]
      public int UserId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Username { get; set; }
      public string Email { get; set; }
      /// <summary> 
      public string? Token { get; set; }
      public string? RefreshToken { get; set; }
      public DateTime RefreshTokenExpiryTime { get; set; }
      /// </summary> 
      public byte[] PasswordSalt { get; set; }
      public byte[] PasswordHash { get; set; }
      public bool Status { get; set; }

   }
}
