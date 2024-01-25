using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Transversal.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v1
{
    [Authorize]
    [EnableRateLimiting("fixedWindow")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesApplication _categoriesApplication;

        public CategoriesController(ICategoriesApplication categoriesApplication)
        {
            _categoriesApplication = categoriesApplication;
        }

        [HttpGet("GetCategoriesAsync")]
        [SwaggerOperation(
            summary: "Get Categories",
            Description = "This endpoint will retunr all categories",
            OperationId = "GetCategoriesAsync",
            Tags = new string[] { "CategoriesAsync" })]
        [SwaggerResponse(200, description: "List of categories", typeof(Response<IEnumerable<CategoryDto>>))]
        [SwaggerResponse(404, "Categories not found")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _categoriesApplication.GetAll();
            return Ok(categories);
        }
    }
}
