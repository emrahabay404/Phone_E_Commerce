using Microsoft.AspNetCore.Mvc;
using MongoDb_Basic_Api.Models;
using MongoDb_Basic_Api.Services;

namespace MongoDb_Basic_Api.Controllers
{
   [Route("api/[controller]/[action]")]
   [ApiController]
   public class MusicController : ControllerBase
   {
      private readonly UserMusicFavoritesService _musicService;
      public MusicController(UserMusicFavoritesService musicService)
      {
         _musicService = musicService;
      }

      // GET: api/Music/Get
      [HttpGet]
      public IEnumerable<UserMusicFavorite> Get()
      {
         return _musicService.Get();
      }

      // GET: api/Music/GetUserById/5
      [HttpGet("{userId}")]
      public UserMusicFavorite GetByUserId(int userId)
      {
         return _musicService.GetByUserId(userId);
      }

      // POST: api/Music/Post
      [HttpPost]
      public void Post([FromBody] UserMusicFavorite value)
      {
         _musicService.Create(value);
      }

      // PUT: api/Music/Put
      [HttpPut]
      public void Put([FromBody] UserMusicFavorite value)
      {
         _musicService.Update(value.Id, value);
      }

      // DELETE: api/Music/Delete/id
      [HttpDelete("{id}")]
      public void Delete(string id)
      {
         _musicService.Remove(id);
      }

   }
}
