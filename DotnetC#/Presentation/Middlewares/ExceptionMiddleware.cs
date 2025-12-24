
using DotnetC_.Domain.Exceptions;
using DotnetC_.Domain.Entities;

namespace DotnetC_.Middlewares;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        int statusCode;
        string message;

        switch (ex)
        {
            case NotFoundException:
                statusCode = StatusCodes.Status404NotFound;
                message = ex.Message;
                break;

            case BadRequestException:
                statusCode = StatusCodes.Status400BadRequest;
                message = ex.Message;
                break;

            case ForbiddenException:
                statusCode = StatusCodes.Status403Forbidden;
                message = ex.Message;
                break;

            case UnauthorizedAccessException:
                statusCode = StatusCodes.Status401Unauthorized;
                message = "Unauthorized";
                break;

            default:
                statusCode = StatusCodes.Status500InternalServerError;
                message = "Internal Server Error";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsJsonAsync(new ErrorResponse
        {
            StatusCode = statusCode,
            Message = message
        });
    }
}
