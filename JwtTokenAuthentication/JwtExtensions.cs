using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtTokenAuthentication
{
   public static class JwtExtensions
   {
      public const string SecurityKey = "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM";

      public static void AddJwtAuthentication(this IServiceCollection services)
      {
         services.AddAuthentication(options =>
         {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
         })
         .AddJwtBearer(options =>
         {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidAudience = "https://localhost:7144",
               ValidIssuer = "https://localhost:7144",
               ValidateIssuerSigningKey = true,
               ClockSkew = TimeSpan.Zero,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey))
            };
         });
      }
   }
}