namespace MongoDb_Basic_Api.Models
{
   public class MongoDBSettings : IMongoDBSettings
   {
      public string CollectionName { get; set; }
      public string ConnectionString { get; set; }
      public string DatabaseName { get; set; }
   }
}
