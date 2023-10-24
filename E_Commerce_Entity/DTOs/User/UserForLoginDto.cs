using E_Commerce_Core.Entities;

namespace E_Commerce_Entity.DTOs.User
{
   public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
