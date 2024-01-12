using MicroServices.Data.Models;

namespace Auth.Api.Services
{
   public interface IAuthService
   {
      Task<(int, string)> Registeration(RegistrationModel model, string role);
      Task<(int, string)> Login(LoginModel model);
   }
}
