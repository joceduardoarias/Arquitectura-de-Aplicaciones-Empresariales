using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Pacagroup.Ecommerce.Application.Interface.UseCase;

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

}
