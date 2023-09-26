using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        // allow execute that next method and pass on the request to the next piece of middleware.
        //ILogger can log any exception
        //IHostEnvironment can check to see if we're running in production mode or in development mode.
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _environment;
        public ExceptionMiddleware(RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = new ProblemDetails()
                {
                    Status = 500,
                    Detail = _environment.IsDevelopment() ? ex.StackTrace?.ToString() : null,
                    Title = ex.Message
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
