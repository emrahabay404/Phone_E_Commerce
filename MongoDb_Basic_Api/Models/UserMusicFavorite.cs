using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_Basic_Api.Models
{
   public class UserMusicFavorite
   {
      [BsonId]
      [BsonRepresentation(BsonType.ObjectId)]
      public string? Id { get; set; }
      public int UserId { get; set; }
      public List<Music> Favourites { get; set; }
   }
}
