using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using System;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerApplication _customerApplication;
        public CustomerController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        #region Metodos Sincronos
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerApplication.GetCustomers();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomer(string id)
        {
            var customer = _customerApplication.GetCustomer(id);
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult InsertCustomer([FromBody] CustomersDto customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = _customerApplication.InsertCustomer(customerDTO);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] CustomersDto customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = _customerApplication.UpdateCustomer(customerDTO);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = _customerApplication.DeleteCustomer(id);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion
        
        #region Metodos Asincronos
        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var customers = await _customerApplication.GetCustomersAsync();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(string id)
        {
            var customer = await _customerApplication.GetCustomerAsync(id);
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCustomerAsync([FromBody] CustomersDto customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _customerApplication.InsertCustomerAsync(customerDTO);
                return Ok(new { Message = "Customer created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] CustomersDto customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _customerApplication.UpdateCustomerAsync(customerDTO);
                return Ok(new { Message = "Customer updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _customerApplication.DeleteCustomerAsync(id);
                return Ok(new { Message = "Customer deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion
    }
}
