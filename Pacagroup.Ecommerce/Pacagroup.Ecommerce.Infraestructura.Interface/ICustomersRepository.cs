using System;
using System.Collections.Generic;
using System.Text;
using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Infraestructura.Interface
{
    public interface ICustomersRepository 
    {
        #region "Metodos Sincronos"
        IEnumerable<Customers> GetCustomers();
        Customers GetCustomer(string customerId);
        bool InsertCustomer(Customers customer);
        bool UpdateCustomer(Customers customer);
        bool DeleteCustomer(string customerId);
        #endregion
        
        #region "Metodos Asincronos"
        IEnumerable<Customers> GetCustomersAsync();
        Customers GetCustomerAsync(string customerId);
        bool InsertCustomerAsync(Customers customer);
        bool UpdateCustomerAsync(Customers customer);
        bool DeleteCustomerAsync(string customerId);
        #endregion
        
    }
}
