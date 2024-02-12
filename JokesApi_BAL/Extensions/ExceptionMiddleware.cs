using JokesApi_BAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;


namespace JokesApi_BAL.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
           
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BadHttpRequestException badReqEx)
            {
                //_logger.LogError($"A new bad http request exception has been thrown: {badReqEx}");
                await HandleExceptionAsync(httpContext, badReqEx);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Exception occurred: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                BadHttpRequestException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = statusCode,
                Message = exception.Message,
            }.ToString());
        }
    }
}
