namespace Morali.Application.Common.Results;

public interface IResult
{
    bool Success { get; }
    Error? Error { get; }
    void SetError(string message, Dictionary<string, IEnumerable<string>>? details = null);
   
}