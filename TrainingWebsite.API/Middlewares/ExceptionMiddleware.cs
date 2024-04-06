using System.Net;
using TrainingWebsite.API.Models;
using TrainingWebsite.Application.Exceptions;

namespace TrainingWebsite.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomProblemDetails problem;

        switch (exception)
        {
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomProblemDetails()
                {
                    Status = (int)statusCode,
                    Title = badRequestException.Message,
                    Detail = badRequestException.InnerException?.Message,
                    Type = nameof(BadRequestException),
                    Errors = badRequestException.ValidationErrors
                };
                break;
            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                problem = new CustomProblemDetails()
                {
                    Status = (int)statusCode,
                    Title = notFoundException.Message,
                    Detail = notFoundException.InnerException?.Message,
                    Type = nameof(NotFoundException)
                };
                break;
            case UnAuthorizedException unAuthorizedException:
                statusCode = HttpStatusCode.Unauthorized;
                problem = new CustomProblemDetails()
                {
                    Status = (int)statusCode,
                    Title = unAuthorizedException.Message,
                    Detail = unAuthorizedException.InnerException?.Message,
                    Type = nameof(UnAuthorizedException)
                };
                break;
                
            default:
                problem = new CustomProblemDetails { Title = exception.Message, Status = (int)statusCode, Detail = exception.StackTrace, Type = nameof(HttpStatusCode.InternalServerError) };
                break;
                
        }
        
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(problem);
    }
}