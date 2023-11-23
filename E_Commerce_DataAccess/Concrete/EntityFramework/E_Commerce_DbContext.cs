using E_Commerce_Core.Entities.Concrete;
using E_Commerce_Core.Utilities.IoC;
using E_Commerce_Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataAccess.Concrete.EntityFramework
{
   public class E_Commerce_DbContext : DbContext
   {
      //public E_Commerce_DbContext(DbContextOptions<E_Commerce_DbContext> options) : base(options) { }
     // IConfiguration _configuration;

      //public E_Commerce_DbContext()
      //{
      //   var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;

      //   switch (assemblyName)
      //   {
      //      case "E_Commerce_API":
      //         _configuration = ServiceTool
      //             .GetInstance<IConfiguration>();
      //         break;
      //      default:
      //         _configuration = ServiceTool.ServiceProvider
      //             .GetRequiredService<IConfiguration>();
      //         break;
      //   }
      //}

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Ms_Sql_Conn"));
         optionsBuilder.UseSqlServer(@"Server=MYPC\SQLEXPRESS;Database=E_Commerce_Db_New;Trusted_Connection=true;TrustServerCertificate=True;");
      }

      public DbSet<Brand> Brands { get; set; }
      public DbSet<Order> Orders { get; set; }
      public DbSet<Model> Models { get; set; }
      public DbSet<OrderDetail> OrderDetails { get; set; }
      public DbSet<E_Commerce_Entity.Concrete.Version> Versions { get; set; }
      public DbSet<Product> Products { get; set; }
      public DbSet<Category> Categories { get; set; }
      public DbSet<Customer> Customers { get; set; }
      public DbSet<OperationClaim> OperationClaims { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

   }
}
