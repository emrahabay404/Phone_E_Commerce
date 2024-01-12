using MicroServices.Data.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace AuthApi.Tests
{
   public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
   {
      private readonly WebApplicationFactory<Program> _webApplicationFactory;

      public AuthControllerTests(WebApplicationFactory<Program> webApplicationFactory)
      {
         _webApplicationFactory = webApplicationFactory;
      }

      [Fact]
      public async Task GivenAValidUser_WhenLoggingIn_ThenReturnsJwtToken()
      {
         // Arrange
         var client = _webApplicationFactory.CreateClient();
         var user = new LoginModel("username", "mypassword");

         // Act
         var result = await client.PostAsJsonAsync("/api/Authentication/login", user);
         var content = await result.Content.ReadAsStringAsync();
         var jwtToken = JsonConvert.DeserializeObject<AuthenticationToken>(content);

         // Assert
         Assert.NotNull(jwtToken);
      }

      [Fact]
      public async Task GivenAnInvalidUser_WhenLoggingIn_ThenReturnsUnauthorized()
      {
         // Arrange
         var client = _webApplicationFactory.CreateClient();
         var user = new LoginModel("username", "mypassword");

         // Act
         var result = await client.PostAsJsonAsync("/api/Authentication/login", user);

         // Assert
         Assert.Equal(HttpStatusCode.Unauthorized, result.StatusCode);
      }

   }
}