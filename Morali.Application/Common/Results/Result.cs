using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Morali.Application.Common.Results;

public class Result<TData> : IResult
{
    public int StatusCode { get; private set; }
    public bool Success { get; private set; }
    public TData? Data { get; private set; }
    public Error? Error { get; private set; }

    public Result<TData> Ok(TData data) => new()
    {
        StatusCode = StatusCodes.Status200OK,
        Data = data?.GetType().GetProperties().Length > 1 ? data : Data,
        Success = true
    };
    
    public Result<TData> NoContent() => new()
    {
        StatusCode = StatusCodes.Status204NoContent,
        Success = true
    };

    public Result<TData> Created(TData data) => new()
    {
        StatusCode = StatusCodes.Status201Created,
        Data = data,
        Success = true
    };
    
    public Result<TData> BadRequest(string message, Dictionary<string, IEnumerable<string>>? details = null) => new()
    {
        StatusCode = StatusCodes.Status400BadRequest,
        Error = new Error(message, details),
        Success = false
    };
    
    public Result<TData> NotFound(string message, Dictionary<string, IEnumerable<string>>? details = null) => new()
    {
        StatusCode = StatusCodes.Status404NotFound,
        Error = new Error(message, details),
        Success = false
    };
    
    public Result<TData> Conflict(string message, Dictionary<string, IEnumerable<string>>? details = null) => new()
    {
        StatusCode = StatusCodes.Status409Conflict,
        Error = new Error(message, details),
        Success = false
    };
    
    public Result<TData> Unauthorized(string message, Dictionary<string, IEnumerable<string>>? details = null) => new()
    {
        StatusCode = StatusCodes.Status401Unauthorized,
        Error = new Error(message, details),
        Success = false
    };
    
    public void SetError(string message, Dictionary<string, IEnumerable<string>>? details = null)
    {
        StatusCode = StatusCodes.Status400BadRequest;
        Error = new Error(message, details);
        Success = false;
    }
    
    public IActionResult ToActionResult()
    {
        return new ObjectResult(this)
        {
            Value = new ResultValue<TData>(Success, Data, Error),
            StatusCode = StatusCode,
        };
    }
}