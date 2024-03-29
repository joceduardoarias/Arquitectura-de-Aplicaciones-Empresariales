﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Pacagroup.Ecommerce.Persistence.Context;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Domain.Entities;

namespace Pacagroup.Ecommerce.Persistence.Repositories
{
    public class CustomerRepository : ICustomersRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }
        #region Métodos Síncronos
        public bool Delete(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var rs = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return rs > 0;
            }
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var rs = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return rs > 0;
            }
        }

        public Customer Get(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var rs = connection.QuerySingle<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return rs;
            }
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                var rs = await connection.QuerySingleAsync<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return rs;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";
                var rs = connection.Query<Customer>(query, commandType: CommandType.StoredProcedure);
                return rs;
            }
        }
        public IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("pPageNumber", pageNumber);
            parameters.Add("pPageSize", pageSize);

            var customers = connection.Query<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);

            return customers;
        }
        public int Count()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Customers";

            var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);

            return count;
        }
        #endregion

        #region Métodos Asíncronos

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersList";
                var rs = await connection.QueryAsync<Customer>(query, commandType: CommandType.StoredProcedure);
                return rs;
            }
        }

        public bool Insert(Customer customer)
        {
            using (var connection = _context.CreateConnection())
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

        public async Task<bool> InsertAsync(Customer customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var rs = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                return rs > 0;
            }
        }

        public bool Update(Customer customer)
        {
            using (var connection = _context.CreateConnection())
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

        public async Task<bool> UpdateAsync(Customer customer)
        {
            using (var connection = _context.CreateConnection())
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

                var rs = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return rs > 0;
            }
        }

        public async Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(*) from Customers";

            var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);

            return count;
        }

        public async Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("pPageNumber", pageNumber);
            parameters.Add("pPageSize", pageSize);

            var customers = connection.Query<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);

            return customers;
        }
        #endregion
    }
}
