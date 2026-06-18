using System.Net;
using System.Text.Json;
using EnglishLearning.Application.Common.Constants;
using EnglishLearning.Application.Common.Exceptions;
using EnglishLearning.Application.Common.Messages;
using EnglishLearning.Application.Common.Models;

namespace EnglishLearning.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, response) = exception switch
        {
            NotFoundException notFound => (
                HttpStatusCode.NotFound,
                new ApiErrorResponse
                {
                    Success = false,
                    Message = notFound.Message,
                    ErrorCode = notFound.ErrorCode
                }),
            ValidationException validation => (
                HttpStatusCode.BadRequest,
                new ApiErrorResponse
                {
                    Success = false,
                    Message = validation.Message,
                    ErrorCode = validation.ErrorCode,
                    Errors = validation.Errors
                }),
            _ => (
                HttpStatusCode.InternalServerError,
                new ApiErrorResponse
                {
                    Success = false,
                    Message = CommonMessages.UnexpectedError,
                    ErrorCode = GlobalErrorCodes.SunucuHatasi
                })
        };

        if (exception is not (NotFoundException or ValidationException))
        {
            _logger.LogError(exception, "Islenmeyen hata olustu.");
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(json);
    }
}
