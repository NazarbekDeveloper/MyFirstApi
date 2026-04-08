using Microsoft.Data.SqlClient;
using System.Data;

namespace MyFirstApi.Data
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public IDbConnection GetConnection()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }
    }
}
