using System.Text.Json;
using EfCoreSqliteLibs.Exceptions;
using EfCoreSqliteLibs.Models;

namespace EfCoreSqliteServiceApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // call next Middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                int statusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                var response = new ResponseModel<object>
                {
                    IsSuccess = false,
                    StatusCode = statusCode,
                    Message = ex.Message,
                    TaceId = context.TraceIdentifier,
                    DataResult = null
                };

                var result = JsonSerializer.Serialize(response, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
