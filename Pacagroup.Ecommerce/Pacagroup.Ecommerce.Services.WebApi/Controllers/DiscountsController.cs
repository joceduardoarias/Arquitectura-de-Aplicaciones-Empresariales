using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Application.UseCase.Customers;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers;

[Authorize]
[EnableRateLimiting("fixedWindow")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class DiscountsController : Controller
{
    private readonly IDiscountsApplication _discountsApplication;

    public DiscountsController(IDiscountsApplication discountsApplication)
    {
        _discountsApplication = discountsApplication;
    }

    [HttpGet("GetDiscountById/{id}")]
    public async Task<IActionResult> GetDiscountById(string id)
    {
        var categories = await _discountsApplication.Get(int.Parse(id));
        return Ok(categories);
    }

    [HttpGet("GetAllDiscounts")]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _discountsApplication.GetAll();
        return Ok(categories);
    }
    [HttpPost("InsertDiscount")]
    public async Task<IActionResult> InsertDiscount([FromBody] DiscountDto discountDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            await _discountsApplication.Create(discountDto);
            return Ok(new { Message = "Discount created successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete("DeleteDiscount/{id}")]
    public async Task<IActionResult> DeleteCustomerAsync(string id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            await _discountsApplication.Delete(int.Parse(id));
            return Ok(new { Message = "Discount deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPost("UpdateDiscount")]
    public async Task<IActionResult> UpdateDiscount([FromBody] DiscountDto discountDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            await _discountsApplication.Update(discountDto);
            return Ok(new { Message = "Discount Updated successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
