using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DL
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string Get()
        {
            return _connectionString.ToString();
        }

    }
}
