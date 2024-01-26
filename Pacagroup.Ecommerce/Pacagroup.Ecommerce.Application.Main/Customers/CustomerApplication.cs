using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Pacagroup.Ecommerce.Application.UseCase.Customers
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerApplication> _logger;
        public CustomerApplication(IUnitOfWork customerDomain, IMapper mapper, ILogger<CustomerApplication> logger)
        {
            _unitOfWork = customerDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public Response<bool> DeleteCustomer(string customerId)
        {
            var response = new Response<bool>();
            
                response.Data = _unitOfWork.customersRepository.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Customer borrado correctamente");
                }                                        
            
            return response;
        }

        public async Task<Response<bool>> DeleteCustomerAsync(string customerId)
        {
            var response = new Response<bool>();
            
                response.Data = await _unitOfWork.customersRepository.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                }
            
            
            return response;
        }

        public ResponsePagination<IEnumerable<CustomerDto>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDto>>();
            
                var count = _unitOfWork.customersRepository.Count();
                var custOmers = _unitOfWork.customersRepository.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(custOmers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta Paginada Exitosa!!!";
                }
            
            
            return response;
        }

        public async Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDto>>();
            
                var count = await _unitOfWork.customersRepository.CountAsync();
                var custOmers = await _unitOfWork.customersRepository.GetAllWithPaginationAsync(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(custOmers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta Paginada Exitosa!!!";
                }
            
            
            return response;
        }

        public Response<CustomerDto> GetCustomer(string customerId)
        {
            var response = new Response<CustomerDto>();
            
                response.Data = _mapper.Map<CustomerDto>(_unitOfWork.customersRepository.Get(customerId));
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Customer obtenido correctamente");
                }
            
            return response;
        }

        public async Task<Response<CustomerDto>> GetCustomerAsync(string customerId)
        {
            var response = new Response<CustomerDto>();
            
                response.Data = _mapper.Map<CustomerDto>(await _unitOfWork.customersRepository.GetAsync(customerId));
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Customer obtenido correctamente");
                }
            
            return response;
        }

        public Response<IEnumerable<CustomerDto>> GetCustomers()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            
                var customers = _unitOfWork.customersRepository.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                if (response.Data.Any())
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Customers obtenidos correctamente");
                }
            
            return response;
        }

        public async Task<Response<IEnumerable<CustomerDto>>> GetCustomersAsync()
        {
            var response = new Response<IEnumerable<CustomerDto>>();
            
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(await _unitOfWork.customersRepository.GetAllAsync());
                if (response.Data.Any())
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Customers obtenidos correctamente");
                }
            
            return response;
        }

        public Response<bool> InsertCustomer(CustomerDto customerDTO)
        {
            var response = new Response<bool>();
            
                var customerEntity = _mapper.Map<Customer>(customerDTO);
                response.Data = _unitOfWork.customersRepository.Insert(customerEntity);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Customer insertado correctamente");
                }
            
            return response;
        }

        public async Task<Response<bool>> InsertCustomerAsync(CustomerDto customerDTO)
        {
            var response = new Response<bool>();
            
                var customerEntity = _mapper.Map<Customer>(customerDTO);
                response.Data = await _unitOfWork.customersRepository.InsertAsync(customerEntity);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Customer insertado correctamente");
                }
            
            return response;
        }

        public Response<bool> UpdateCustomer(CustomerDto customerDTO)
        {
            var response = new Response<bool>();
            
                var customerEntity = _mapper.Map<Customer>(customerDTO);
                response.Data = _unitOfWork.customersRepository.Update(customerEntity);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Customer actualizado correctamente");
                }
            
            return response;
        }

        public async Task<Response<bool>> UpdateCustomerAsync(CustomerDto customerDTO)
        {
            var response = new Response<bool>();
            
                var customerEntity = _mapper.Map<Customer>(customerDTO);
                response.Data = await _unitOfWork.customersRepository.UpdateAsync(customerEntity);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Success";
                    _logger.LogInformation("Customer actualizado correctamente");
                }
            
            return response;
        }
    }
}
