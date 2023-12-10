using System;
using System.Collections.Generic;
using System.Text;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infraestructura.Interface;
using System.Threading.Tasks;
using Pacagroup.Ecommerce.Infraestructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool DeleteCustomer(string customerId)
        {
            return _unitOfWork.customersRepository.Delete(customerId);
        }
        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            return await _unitOfWork.customersRepository.DeleteAsync(customerId);
        }
        public Customers GetCustomer(string customerId)
        {
            return _unitOfWork.customersRepository.Get(customerId);
        }
        public async Task<Customers> GetCustomerAsync(string customerId)
        {
            return await _unitOfWork.customersRepository.GetAsync(customerId);
        }

        public IEnumerable<Customers> GetCustomers()
        {
            return _unitOfWork.customersRepository.GetAll();
        }

        public async Task<IEnumerable<Customers>> GetCustomersAsync()
        {
            return await _unitOfWork.customersRepository.GetAllAsync();
        }

        public bool InsertCustomer(Customers customer)
        {
            return _unitOfWork.customersRepository.Insert(customer);
        }

        public async Task<bool> InsertCustomerAsync(Customers customer)
        {
            return await _unitOfWork.customersRepository.InsertAsync(customer);
        }

        public bool UpdateCustomer(Customers customer)
        {
            return _unitOfWork.customersRepository.Update(customer);
        }

        public async Task<bool> UpdateCustomerAsync(Customers customer)
        {
            return await _unitOfWork.customersRepository.UpdateAsync(customer);
        }
    }
}
