﻿namespace PostgreSql_Basic_Api.Models
{
   public class Movie
   {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Content { get; set; }
      public DateTime CreatedAt { get; set; }
   }
}
