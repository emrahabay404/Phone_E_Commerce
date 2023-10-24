using E_Commerce_Core.Entities;

namespace E_Commerce_Entity.Concrete
{
   public class TokenModel :IEntity
   {
      public string? AccessToken { get; set; }
      public string? RefreshToken { get; set; }
   }
}
