using SmartLMS.Application.Common.Exceptions;
using SmartLMS.Domain.Common.Exceptions;
using SmartLMS.Infrastructure.Persistence.Exceptions;
using System.Net;
using System.Text.Json;

namespace SmartLMS.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (RecordNotFoundException ex)
        {
            _logger.LogInformation(ex, "Not found");

            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new
            {
                errorCode = "NotFound",
                message = ex.Message
            });
        }
        catch (NotFoundException ex)
        {
            _logger.LogInformation(ex, "Not found");

            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new
            {
                errorCode = "NotFound",
                message = ex.Message
            });
        }
        catch (DomainException ex)
        {
            _logger.LogWarning(ex, "Domain error");

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            var response = new
            {
                errorCode = ex.ErrorCode,
                message = ex.Message
            };
            await context.Response.WriteAsJsonAsync(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            var response = new
            {
                errorCode = "ServerError",
                message = "An unexpected error occurred."
            };
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
