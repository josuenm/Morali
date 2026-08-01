using Morali.Application.Common.Results;

namespace Morali.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext ctx)
    {
        try
        {
            await _next(ctx);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(ctx, ex);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode;
        Error error;

        switch (exception)
        {
            default:
                _logger.LogError(exception, "Erro não tratado {Message}", exception.Message);
                statusCode = StatusCodes.Status500InternalServerError;
                error = new Error("Erro interno no servidor", null);
                break;
        }
        
        var result = new ResultValue<object>(false, null, error);
        
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(result);
    }
}