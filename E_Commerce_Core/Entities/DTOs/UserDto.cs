namespace E_Commerce_Core.Entities.DTOs
{
   public class UserDto : IDto
   {
      public int UserId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Username { get; set; }
      public string Email { get; set; }
      /// <summary>
      public string Token { get; set; } = string.Empty;
      public DateTime TokenCreated { get; set; }
      public DateTime TokenExpires { get; set; }
      /// </summary>
      public byte[] PasswordSalt { get; set; }
      public byte[] PasswordHash { get; set; }
      public bool Status { get; set; }
   }
}
