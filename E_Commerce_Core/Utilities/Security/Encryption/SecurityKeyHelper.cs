using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_Commerce_Core.Utilities.Security.Encryption
{
   public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
