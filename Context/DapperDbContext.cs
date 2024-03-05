using Microsoft.Data.SqlClient;
using System.Data;

namespace learndapper.Context
{
    public class DapperDbContext
    {

        private readonly IConfiguration config;
        private readonly string connectionStr;
        public DapperDbContext(IConfiguration configuration)
        {
            this.config = configuration;
            this.connectionStr = this.config.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionStr);
    }
}
 