using CleanTeeth.Application.Exceptions;
using CleanTeeth.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace CleanTeeth.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;

            switch (exception)
            {
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case BusinessRuleException businessRuleException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(businessRuleException.Message);
                    break;
                case CustomValidationException customValidationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(customValidationException.ValidationErrors);
                    break;
                default:
                    break;
            }
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
    public static class ErrorHandlingMiddlewareExtention
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builer)
        {
            return builer.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
