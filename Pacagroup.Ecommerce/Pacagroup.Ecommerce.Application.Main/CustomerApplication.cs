using System;
using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Application.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class CustomerApplication :ICustomerApplication
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IMapper _mapper;
        
        public CustomerApplication(ICustomerDomain customerDomain, IMapper mapper)
        {
            _customerDomain = customerDomain;
            _mapper = mapper;
        }

        public Response<bool> DeleteCustomer(string customerId)
        {   
            var response = new Response<bool>();
            try
            {
                response.Data = _customerDomain.DeleteCustomer(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteCustomerAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customerDomain.DeleteCustomerAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<CustomersDto> GetCustomer(string customerId)
        {
            var response = new Response<CustomersDto>();
            try
            {
                response.Data = _mapper.Map<CustomersDto>(_customerDomain.GetCustomer(customerId));
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<Response<CustomersDto>> GetCustomerAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public Response<IEnumerable<CustomersDto>> GetCustomers()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customers = _customerDomain.GetCustomers();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);
                if (response.Data.Any())
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<Response<IEnumerable<CustomersDto>>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Response<bool> InsertCustomer(CustomersDto customer)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> InsertCustomerAsync(CustomersDto customer)
        {
            throw new NotImplementedException();
        }

        public Response<bool> UpdateCustomer(CustomersDto customer)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateCustomerAsync(CustomersDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
