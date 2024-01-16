using Microsoft.EntityFrameworkCore;

namespace PostgreSql_Basic_Api.Models
{
   public class AppDbContext : DbContext
   {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
      {
      }

      public DbSet<Movie> Movies { get; set; }

   }
}
