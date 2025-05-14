using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MgRequeteClients.DAL
{
    public class ClientDAO
    {
        private readonly string _connectionString;

        public ClientDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

      
    }
}
