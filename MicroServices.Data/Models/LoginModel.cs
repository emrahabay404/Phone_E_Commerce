using System.ComponentModel.DataAnnotations;

namespace MicroServices.Data.Models
{
   public record LoginModel
   {
      public LoginModel(string username, string password)
      {
         Username = username;
         Password = password;
      }

      [Required(ErrorMessage = "User Name is required")]
      public string? Username { get; set; }

      [Required(ErrorMessage = "Password is required")]
      public string? Password { get; set; }

   }
}
