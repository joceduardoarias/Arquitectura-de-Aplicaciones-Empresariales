using Microsoft.AspNetCore.Http;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Net;
using System.Text.Json;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.GlobalException;

public class GlobalExceptionHandler : IMiddleware
{
    private ILogger<GlobalExceptionHandler> _logger;
    private readonly IWebHostEnvironment _env;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocurrió un error no manejado.");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new Response<Object>
            {
                Message = "Se ha producido un error interno del servidor. Por favor, intente más tarde."
            };

            if (_env.IsDevelopment())
            {
                response.Message = ex.Message; // Solo en modo desarrollo
            }

            await JsonSerializer.SerializeAsync(context.Response.Body, response);
        }
    }

}
