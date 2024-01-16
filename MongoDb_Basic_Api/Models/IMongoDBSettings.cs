namespace MongoDb_Basic_Api.Models
{
   public interface IMongoDBSettings
   {
      string CollectionName { get; set; }
      string ConnectionString { get; set; }
      string DatabaseName { get; set; }
   }
}
