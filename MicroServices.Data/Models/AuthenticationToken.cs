namespace MicroServices.Data.Models
{
   public record AuthenticationToken(string Token, int ExpiresIn);
}
