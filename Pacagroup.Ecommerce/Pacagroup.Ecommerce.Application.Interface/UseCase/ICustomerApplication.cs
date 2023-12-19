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
        Response<IEnumerable<CustomersDto>> GetCustomers();
        Response<CustomersDto> GetCustomer(string customerId);
        Response<bool> InsertCustomer(CustomersDto customer);
        Response<bool> UpdateCustomer(CustomersDto customer);
        Response<bool> DeleteCustomer(string customerId);
        ResponsePagination<IEnumerable<CustomersDto>> GetAllWithPagination(int pageNumber, int pageSize);
        #endregion

        #region "Metodos Asincronos"
        Task<Response<IEnumerable<CustomersDto>>> GetCustomersAsync();
        Task<Response<CustomersDto>> GetCustomerAsync(string customerId);
        Task<Response<bool>> InsertCustomerAsync(CustomersDto customer);
        Task<Response<bool>> UpdateCustomerAsync(CustomersDto customer);
        Task<Response<bool>> DeleteCustomerAsync(string customerId);
        Task<ResponsePagination<IEnumerable<CustomersDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion
    }
}
