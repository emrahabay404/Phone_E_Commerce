using Microsoft.EntityFrameworkCore;

namespace PostgreSql_Basic_Api.Models
{
   public class AppDbContext : DbContext
   {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
      {
      }

      public DbSet<CSharpCornerArticle> Articles { get; set; }

   }
}
