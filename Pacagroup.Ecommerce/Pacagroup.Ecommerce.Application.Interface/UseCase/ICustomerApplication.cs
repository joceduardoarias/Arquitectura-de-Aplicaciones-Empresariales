using System;
using System.Collections.Generic;
using System.Text;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Interface.UseCase
{
    public interface ICustomerApplication
    {
        #region "Metodos Sincronos"
        Response<IEnumerable<CustomerDto>> GetCustomers();
        Response<CustomerDto> GetCustomer(string customerId);
        Response<bool> InsertCustomer(CustomerDto customer);
        Response<bool> UpdateCustomer(CustomerDto customer);
        Response<bool> DeleteCustomer(string customerId);
        ResponsePagination<IEnumerable<CustomerDto>> GetAllWithPagination(int pageNumber, int pageSize);
        #endregion

        #region "Metodos Asincronos"
        Task<Response<IEnumerable<CustomerDto>>> GetCustomersAsync();
        Task<Response<CustomerDto>> GetCustomerAsync(string customerId);
        Task<Response<bool>> InsertCustomerAsync(CustomerDto customer);
        Task<Response<bool>> UpdateCustomerAsync(CustomerDto customer);
        Task<Response<bool>> DeleteCustomerAsync(string customerId);
        Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion
    }
}
