namespace E_Commerce_Core.Utilities.Security.JWT
{
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
