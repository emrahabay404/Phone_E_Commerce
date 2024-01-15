namespace ElasticSearch_Basic_Api.Models
{
   public class Product
   {
      public int ProductId { get; set; } = new Random().Next();
      public string ProductName { get; set; }
      public string Description { get; set; }
      public string Category { get; set; }
   }
}
