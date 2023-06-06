using System.Net;
using System.Text.Json;
using Application.Exceptions;
using Application.Models;

namespace WebAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Every request will pass from this middleware
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                Error error = new();
                switch (e)
                {
                    case CustomValidationException valException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        error.FriendlyMessage = valException.FriendlyErrorMessage;
                        error.ErrorMessages = valException.ErrorMessages;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        error.FriendlyMessage = e.Message;
                        break;
                }
                var result = JsonSerializer.Serialize(error);
                await response.WriteAsync(result);
            }

        }
    }
}
