using System;
using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Transversal.Common;
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
                if (response.Data != null)
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

        public async Task<Response<CustomersDto>> GetCustomerAsync(string customerId)
        {   
            var response = new Response<CustomersDto>();
            try
            {
                response.Data = _mapper.Map<CustomersDto>(await _customerDomain.GetCustomerAsync(customerId));
                if (response.Data != null)
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

        public async Task<Response<IEnumerable<CustomersDto>>> GetCustomersAsync()
        {   
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(await _customerDomain.GetCustomersAsync());
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

        public Response<bool> InsertCustomer(CustomersDto customerDTO)
        {   
            var response = new Response<bool>();
            try
            {
                var customerEntity = _mapper.Map<Customers>(customerDTO);
                response.Data = _customerDomain.InsertCustomer(customerEntity);
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

        public async Task<Response<bool>> InsertCustomerAsync(CustomersDto customerDTO)
        {   
            var response = new Response<bool>();
            try
            {
                var customerEntity = _mapper.Map<Customers>(customerDTO);
                response.Data = await _customerDomain.InsertCustomerAsync(customerEntity);
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

        public Response<bool> UpdateCustomer(CustomersDto customerDTO)
        {   
            var response = new Response<bool>();
            try
            {
                var customerEntity = _mapper.Map<Customers>(customerDTO);
                response.Data = _customerDomain.UpdateCustomer(customerEntity);
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

        public async Task<Response<bool>> UpdateCustomerAsync(CustomersDto customerDTO)
        {   
            var response = new Response<bool>();
            try
            {
                var customerEntity = _mapper.Map<Customers>(customerDTO);
                 response.Data = await _customerDomain.UpdateCustomerAsync(customerEntity);
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
    }
}
