using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Application.DTO;
using MediatR;
using Pacagroup.Ecommerce.Application.UseCase.Customers.Queries.GetAllCustomerQuery;
using Pacagroup.Ecommerce.Application.UseCase.Customers.Queries.GetCustomerQuery;
using Pacagroup.Ecommerce.Application.UseCase.Customers.Commands.CreateCustomerCommand;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Pacagroup.Ecommerce.Application.UseCase.Customers.Commands.DeleteCustomerCommand;
using Pacagroup.Ecommerce.Application.UseCase.Customers.Queries.GetCustomerWithPagination;
using Pacagroup.Ecommerce.Application.UseCase.Customers.Commands.UpdateCustomerCommand;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v2;

[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Metodos Asincronos
    [HttpGet("GetCustomersAsync")]
    public async Task<IActionResult> GetCustomersAsync()
    {
        var customers = await _mediator.Send(new GetAllCustomerQuery());
        return Ok(customers);
    }
    [HttpGet("GetCustomerAsync/{id}")]
    public async Task<IActionResult> GetCustomerAsync(GetCustomerQuery query)
    {
        var customer = await _mediator.Send(query);
        return Ok(customer);
    }
    [HttpPost("InsertCustomerAsync")]
    public async Task<IActionResult> InsertCustomerAsync([FromBody] CreateCustomerCommand command)
    {
        if (command == null)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(new { Message = "Customer created successfully" });
            }

            return BadRequest(response.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }        
    }
    [HttpPut("UpdateCustomerAsync")]
    public async Task<IActionResult> UpdateCustomerAsync([FromBody] UpdateCustomerCommand command)
    {
        var customerDto = await _mediator.Send(new GetCustomerQuery() { CustomerId = command.CustomerId });
        
        if (customerDto.Data == null)
        {
            return BadRequest(customerDto.Message);
        }

        var response = await _mediator.Send(command);
        
        if (response.IsSuccess)
        {
            return Ok(response.Message);
        }
        return BadRequest(response.Message);
    }
    [HttpDelete("DeleteCustomerAsync/{id}")]
    public async Task<IActionResult> DeleteCustomerAsync(DeleteCustomerCommand command)
    {
        if (command == null)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var response = await _mediator.Send(command);
            if(response.IsSuccess) 
            {
                return Ok(new { Message = "Customer deleted successfully" });
            }
            return BadRequest(response.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("GetCustomersWithPaginationAsync")]
    public async Task<IActionResult> GetCustomersWithPaginationAsync([FromQuery] GetCustomerWithPaginationQuery query)
    {
        var customers = await _mediator.Send(query);
        return Ok(customers);
    }
    #endregion
}
