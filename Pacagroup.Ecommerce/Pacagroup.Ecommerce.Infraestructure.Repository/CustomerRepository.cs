using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infraestructura.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Pacagroup.Ecommerce.Infraestructure.Repository
{
    public class CustomerRepository : ICustomersRepository
    {   
        private readonly IConnectionFactory _connectionFactory;
        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public bool DeleteCustomer(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var rs = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return rs > 0;
            }
        }

        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var rs = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return rs > 0;
            }
        }

        public Customers GetCustomer(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);                
                var rs = connection.QuerySingle<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return rs;
            }
        }

        public async Task<Customers> GetCustomerAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var rs = await connection.QuerySingleAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return rs;
            }
        }

        public IEnumerable<Customers> GetCustomers()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";
                var rs = connection.Query<Customers>(query, commandType: CommandType.StoredProcedure);
                return rs;
            }
        }

        public async Task<IEnumerable<Customers>> GetCustomersAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";
                var rs = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return rs;
            }
        }

        public bool InsertCustomer(Customers customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTittle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var rs = connection.Execute(query, commandType: CommandType.StoredProcedure);
                return rs > 0;
            }
        }

        public async Task<bool> InsertCustomerAsync(Customers customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTittle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var rs = await connection.ExecuteAsync(query, commandType: CommandType.StoredProcedure);
                return rs > 0;
            }
        }

        public bool UpdateCustomer(Customers customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTittle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var rs = connection.Execute(query, commandType: CommandType.StoredProcedure);
                return rs > 0;
            }
        }

        public async Task<bool> UpdateCustomerAsync(Customers customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTittle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var rs = await connection.ExecuteAsync(query, param: parameters,commandType: CommandType.StoredProcedure);
                return rs > 0;
            }
        }
    }
}
