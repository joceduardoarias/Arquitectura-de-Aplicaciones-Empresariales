using System;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Pacagroup.Ecommerce.Infraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;        
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;            
        }
        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null)
                {
                    return null;
                }
                sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }    
}
