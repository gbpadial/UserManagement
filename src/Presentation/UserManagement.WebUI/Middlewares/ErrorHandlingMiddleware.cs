using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UserManagement.Application.Common.Exceptions;
using UserManagement.Domain.Errors;

namespace UserManagement.WebUI.Middlewares;


public class ErrorHandlingMiddleware() : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var errorResponse = ex switch
        {
            AppException => new ErrorDetails(HttpStatusCode.BadRequest, "An application error occurred"),
            ValidationException => new ErrorDetails(HttpStatusCode.BadRequest, string.Join(',', (ex as ValidationException).Errors.Select(e => e.ErrorMessage))),
            _ => new ErrorDetails(HttpStatusCode.InternalServerError, "An unexpected error occurred")
        };

        response.StatusCode = (int)errorResponse.StatusCode;

        var jsonResponse = JsonSerializer.Serialize(errorResponse, BuildSerializerSettings());

        await response.WriteAsync(jsonResponse);
    }

    private static JsonSerializerOptions BuildSerializerSettings()
    {
        var settings = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return settings;
    }
}
