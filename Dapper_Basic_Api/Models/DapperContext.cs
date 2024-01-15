using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper_Basic_Api.Models
{
   public class DapperContext
   {
      private readonly IConfiguration _configuration;
      private readonly string _connectionString;

      public DapperContext(IConfiguration configuration)
      {
         _configuration = configuration;
         _connectionString = _configuration.GetConnectionString("MSSQLCONN");
      }

      public IDbConnection CreateConnection()
         => new SqlConnection(_connectionString);
   }
}
