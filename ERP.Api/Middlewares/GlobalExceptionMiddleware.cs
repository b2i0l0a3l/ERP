using System.Net;
using System.Security.Authentication;
using ERP.Infrastructure.Shared;

namespace ERP.Api.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public GlobalExceptionMiddleware(
            ILogger<GlobalExceptionMiddleware> logger, 
            RequestDelegate next,
            IWebHostEnvironment env)
        {
            _logger = logger;
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception at {Path}", context.Request.Path);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is CustomValidationException validationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var response = new
                {
                    error = "Validation Failed",
                    errors = validationException.Errors
                };
                return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
            }
            else
            {
                var (status, message) = MapException(exception);
                var response = new
                {
                    error = message,
                    stackTrace = _env.IsDevelopment() ? exception.StackTrace : null
                };
                context.Response.StatusCode = (int)status;
                return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
            }
        }

        private static (HttpStatusCode Status, string Message) MapException(Exception exception)
        {
            return exception switch
            {
                DirectoryNotFoundException or DllNotFoundException or
                EntryPointNotFoundException or FileNotFoundException or KeyNotFoundException
                    => (HttpStatusCode.NotFound, exception.Message),

                NotImplementedException
                    => (HttpStatusCode.NotImplemented, exception.Message),

                UnauthorizedAccessException or AuthenticationException
                    => (HttpStatusCode.Unauthorized, exception.Message),

                _ => (HttpStatusCode.InternalServerError, "An unexpected error occurred. Please try again later.")
            };
        }
    }
}