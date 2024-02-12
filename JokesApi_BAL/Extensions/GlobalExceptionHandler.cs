using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;


namespace JokesApi_BAL.Extensions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            //_logger.LogError(
            //exception, "Exception occurred: {Message}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Detail = exception.Message               
            };

            switch (exception)
            {
                case BadHttpRequestException:
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Title = exception.GetType().Name;
                    break;
                default:
                    problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                    problemDetails.Title = "Internal Server Error";
                    break;
            }
            
            await httpContext
                .Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }

    }
}
