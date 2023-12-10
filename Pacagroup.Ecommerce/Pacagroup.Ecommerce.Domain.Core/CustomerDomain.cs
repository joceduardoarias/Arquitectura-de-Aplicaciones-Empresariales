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
            return _customersRepository.Delete(customerId);
        }
        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            return await _customersRepository.DeleteAsync(customerId);
        }
        public Customers GetCustomer(string customerId)
        {
            return _customersRepository.Get(customerId);
        }
        public async Task<Customers> GetCustomerAsync(string customerId)
        {
            return await _customersRepository.GetAsync(customerId);
        }

        public IEnumerable<Customers> GetCustomers()
        {
            return _customersRepository.GetAll();
        }

        public async Task<IEnumerable<Customers>> GetCustomersAsync()
        {
            return await _customersRepository.GetAllAsync();
        }

        public bool InsertCustomer(Customers customer)
        {
            return _customersRepository.Insert(customer);
        }

        public async Task<bool> InsertCustomerAsync(Customers customer)
        {
            return await _customersRepository.InsertAsync(customer);
        }

        public bool UpdateCustomer(Customers customer)
        {
            return _customersRepository.Update(customer);
        }

        public async Task<bool> UpdateCustomerAsync(Customers customer)
        {
            return await _customersRepository.UpdateAsync(customer);
        }
    }
}
