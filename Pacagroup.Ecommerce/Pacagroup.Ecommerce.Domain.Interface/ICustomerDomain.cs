using System;
using System.Collections.Generic;
using System.Text;
using Pacagroup.Ecommerce.Domain.Entity;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Interface
{
    public interface ICustomerDomain
    {
        #region "Metodos Sincronos"
        IEnumerable<Customers> GetCustomers();
        Customers GetCustomer(string customerId);
        bool InsertCustomer(Customers customer);
        bool UpdateCustomer(Customers customer);
        bool DeleteCustomer(string customerId);
        IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();
        #endregion

        #region "Metodos Asincronos"
        Task<IEnumerable<Customers>> GetCustomersAsync();
        Task<Customers> GetCustomerAsync(string customerId);
        Task<bool> InsertCustomerAsync(Customers customer);
        Task<bool> UpdateCustomerAsync(Customers customer);
        Task<bool> DeleteCustomerAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        #endregion
    }
}
