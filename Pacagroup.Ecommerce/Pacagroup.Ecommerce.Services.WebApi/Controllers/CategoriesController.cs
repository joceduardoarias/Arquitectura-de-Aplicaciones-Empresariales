using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Application.Main;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _categoriesApplication.GetAll();
            return Ok(categories);
        }
    }
}
