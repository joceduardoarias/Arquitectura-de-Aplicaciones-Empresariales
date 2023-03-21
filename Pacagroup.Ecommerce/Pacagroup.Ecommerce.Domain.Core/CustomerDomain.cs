using System;
using System.Collections.Generic;
using System.Text;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infraestructura.Interface;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomerDomain(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public bool DeleteCustomer(string customerId)
        {
            return _customersRepository.DeleteCustomer(customerId);
        }
        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            return await _customersRepository.DeleteCustomerAsync(customerId);
        }
        public Customers GetCustomer(string customerId)
        {
            return _customersRepository.GetCustomer(customerId);
        }
        public async Task<Customers> GetCustomerAsync(string customerId)
        {
            return await _customersRepository.GetCustomerAsync(customerId);
        }

        public IEnumerable<Customers> GetCustomers()
        {
            return _customersRepository.GetCustomers();
        }

        public Task<IEnumerable<Customers>> GetCustomersAsync()
        {
            return _customersRepository.GetCustomersAsync();
        }

        public bool InsertCustomer(Customers customer)
        {
            return _customersRepository.InsertCustomer(customer);
        }

        public Task<bool> InsertCustomerAsync(Customers customer)
        {
            return _customersRepository.InsertCustomerAsync(customer);
        }

        public bool UpdateCustomer(Customers customer)
        {
            return _customersRepository.UpdateCustomer(customer);
        }

        public Task<bool> UpdateCustomerAsync(Customers customer)
        {
            return _customersRepository.UpdateCustomerAsync(customer);
        }
    }
}
