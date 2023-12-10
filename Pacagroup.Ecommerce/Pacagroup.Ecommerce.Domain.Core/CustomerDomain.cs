using System.Collections.Generic;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
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

        #region Metodos Síncronos
        public bool DeleteCustomer(string customerId)
        {
            return _unitOfWork.customersRepository.Delete(customerId);
        }
        
        public Customers GetCustomer(string customerId)
        {
            return _unitOfWork.customersRepository.Get(customerId);
        }
        
        public bool UpdateCustomer(Customers customer)
        {
            return _unitOfWork.customersRepository.Update(customer);
        }

        public IEnumerable<Customers> GetCustomers()
        {
            return _unitOfWork.customersRepository.GetAll();
        }
        
        public bool InsertCustomer(Customers customer)
        {
            return _unitOfWork.customersRepository.Insert(customer);
        }
        public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return _unitOfWork.customersRepository.GetAllWithPagination(pageNumber, pageSize);
        }

        public int Count()
        {
            return _unitOfWork.customersRepository.Count();
        }
        #endregion

        #region Metodos Asíncronos

        public async Task<Customers> GetCustomerAsync(string customerId)
        {
            return await _unitOfWork.customersRepository.GetAsync(customerId);
        }
        public async Task<IEnumerable<Customers>> GetCustomersAsync()
        {
            return await _unitOfWork.customersRepository.GetAllAsync();
        }
        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            return await _unitOfWork.customersRepository.DeleteAsync(customerId);
        }
        public async Task<bool> InsertCustomerAsync(Customers customer)
        {
            return await _unitOfWork.customersRepository.InsertAsync(customer);
        }

        public async Task<bool> UpdateCustomerAsync(Customers customer)
        {
            return await _unitOfWork.customersRepository.UpdateAsync(customer);
        }        
        public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.customersRepository.GetAllWithPaginationAsync(pageNumber, pageSize);
        }
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.customersRepository.CountAsync();
        }

        #endregion
    }
}
